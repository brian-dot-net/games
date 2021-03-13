#include <gtest/gtest.h>
#include "Hashtable.h"
#include <string>
#include <sstream>

using namespace std;

struct MyKey
{
    int value_;

    bool operator==(const MyKey& other) const
    {
        return value_ == other.value_;
    }
};

namespace std
{
    template<> struct hash<MyKey>
    {
        size_t operator()(const MyKey& k) const noexcept
        {
            return k.value_;
        }
    };
}

namespace Words
{
    void TestIncreasingTableSizeKeyNotFound(Hashtable<MyKey, int>& table)
    {
        for (int i = 0; i < 1000; ++i)
        {
            bool inserted = table.insert({ i }, i + 1);
            ASSERT_TRUE(inserted);

            int v;
            bool found = table.get({ i + 1 }, v);
            ASSERT_FALSE(found);
        }
    }

    TEST(HashtableTest, EmptyTableFindsNothing)
    {
        Hashtable<string, int> table;

        int v;
        bool found = table.get("not-here", v);

        ASSERT_FALSE(found);
    }

    TEST(HashtableTest, OneEntryTableKeyNotFound)
    {
        Hashtable<string, int> table;

        table.insert("here", 11);
        int v;
        bool found = table.get("not-here", v);

        ASSERT_FALSE(found);
    }

    TEST(HashtableTest, OneEntryTableKeyFound)
    {
        Hashtable<string, int> table;

        table.insert("here", 11);
        int v = 0;
        bool found = table.get("here", v);

        ASSERT_TRUE(found);
        ASSERT_EQ(11, v);
    }

    TEST(HashtableTest, OneEntryTableKeyReplaced)
    {
        Hashtable<string, int> table;

        bool first = table.insert("overwrite", 10);
        bool second = table.insert("overwrite", 100);
        int v = 0;
        bool found = table.get("overwrite", v);

        ASSERT_TRUE(first);
        ASSERT_FALSE(second);
        ASSERT_TRUE(found);
        ASSERT_EQ(100, v);
    }

    TEST(HashtableTest, InsertAndReplaceManyEntriesResize)
    {
        const int Size = 1000;
        Hashtable<string, int> table;

        for (int i = 1; i <= Size; ++i)
        {
            stringstream s;
            s << "k" << i;
            string key(s.str());
            bool inserted = table.insert(key, i);
            ASSERT_TRUE(inserted);
        }

        for (int i = 1; i <= Size; ++i)
        {
            stringstream s;
            s << "k" << i;
            string key(s.str());
            int v = 0;
            bool found = table.get(key, v);
            ASSERT_TRUE(found);
            ASSERT_EQ(i, v);
        }

        for (int i = 1; i <= Size; ++i)
        {
            stringstream s;
            s << "k" << i;
            string key(s.str());
            int prev = 0;
            bool inserted = table.insert(key, i * 2, &prev);
            ASSERT_FALSE(inserted);
            ASSERT_EQ(i, prev);
        }

        for (int i = 1; i <= Size; ++i)
        {
            stringstream s;
            s << "k" << i;
            string key(s.str());
            int v = 0;
            bool found = table.get(key, v);
            ASSERT_TRUE(found);
            ASSERT_EQ(i * 2, v);
        }
    }

    TEST(HashtableTest, IncreasingTableSizeKeyNotFound)
    {
        Hashtable<MyKey, int> table;
        TestIncreasingTableSizeKeyNotFound(table);
    }

    TEST(HashtableTest, IncreasingTableSizeKeyNotFoundLowerLoadFactor)
    {
        Hashtable<MyKey, int> table(0.25f);
        TestIncreasingTableSizeKeyNotFound(table);
    }
}
