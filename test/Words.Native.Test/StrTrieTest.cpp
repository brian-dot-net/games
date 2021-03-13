#include <gtest/gtest.h>
#include "StrTrie.h"

using namespace std;

namespace Words
{
    istream& Load(stringstream& stream, initializer_list<const char*> lines)
    {
        for (const char* line : lines)
        {
            stream << line << "\r\n";
        }

        stream.seekg(0);
        return stream;
    }

    TEST(StrTrieTest, Empty)
    {
        StrTrie trie;

        ASSERT_EQ(size_t(0), trie.size());
    }

    TEST(StrTrieTest, OneItemLength1)
    {
        StrTrie trie;

        trie.insert("X");

        ASSERT_EQ(size_t(1), trie.size());
    }

    TEST(StrTrieTest, TwoItemsLength2SharedPrefix)
    {
        StrTrie trie;

        trie.insert("HI");
        trie.insert("HA");

        ASSERT_EQ(size_t(2), trie.size());
        ASSERT_EQ(StrTrie::Prefix, trie.find("H"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("HA"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("HI"));
    }

    TEST(StrTrieTest, ThreeItemsLength3NoSharedPrefix)
    {
        StrTrie trie;

        trie.insert("ABC");
        trie.insert("DEF");
        trie.insert("GHI");

        ASSERT_EQ(size_t(3), trie.size());
        ASSERT_EQ(StrTrie::Prefix, trie.find("A"));
        ASSERT_EQ(StrTrie::Prefix, trie.find("AB"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("ABC"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("DEF"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("GHI"));
    }

    TEST(StrTrieTest, GetNonExistentNode)
    {
        StrTrie trie;
        trie.insert("ABC");

        ASSERT_EQ(StrTrie::None, trie.find("X"));
    }

    TEST(StrTrieTest, AddNodesMultipleTimes)
    {
        StrTrie trie;

        trie.insert("AB");
        trie.insert("AB");
        trie.insert("ABC");
        trie.insert("ABC");

        ASSERT_EQ(size_t(2), trie.size());
        ASSERT_EQ(StrTrie::Prefix, trie.find("A"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("AB"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("ABC"));
    }

    TEST(StrTrieTest, AddNodesMultipleTimesLongerFirst)
    {
        StrTrie trie;

        trie.insert("ABC");
        trie.insert("ABC");
        trie.insert("AB");
        trie.insert("AB");

        ASSERT_EQ(size_t(2), trie.size());
        ASSERT_EQ(StrTrie::Prefix, trie.find("A"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("AB"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("ABC"));
    }

    TEST(StrTrieTest, AddEmptyNode)
    {
        StrTrie trie;

        trie.insert("");

        ASSERT_EQ(size_t(0), trie.size());
    }

    TEST(StrTrieTest, LoadFromStreamEmpty)
    {
        stringstream stream;
        StrTrie trie(Load(stream, {}));

        ASSERT_EQ(size_t(0), trie.size());
    }

    TEST(StrTrieTest, LoadFromStreamOneWord)
    {
        stringstream stream;
        StrTrie trie(Load(stream, { "ONE" }));

        ASSERT_EQ(size_t(1), trie.size());
        ASSERT_EQ(StrTrie::Terminal, trie.find("ONE"));
    }

    TEST(StrTrieTest, LoadFromStreamThreeWords)
    {
        stringstream stream;
        StrTrie trie(Load(stream, { "ONE", "TWO", "THREE" }));

        ASSERT_EQ(size_t(3), trie.size());
        ASSERT_EQ(StrTrie::Terminal, trie.find("ONE"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("TWO"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("THREE"));
    }

    TEST(StrTrieTest, LoadFromStreamSomeWordsTooShort)
    {
        stringstream stream;
        StrTrie trie(Load(stream, { "S", "SH", "LONG" }));

        ASSERT_EQ(size_t(1), trie.size());
        ASSERT_EQ(StrTrie::Terminal, trie.find("LONG"));
    }

    TEST(StrTrieTest, LoadFromStreamSomeWordsTooLong)
    {
        stringstream stream;
        StrTrie trie(Load(stream, { "OK", "OKAY", "THISISTOOLONG", "YES" }));

        ASSERT_EQ(size_t(2), trie.size());
        ASSERT_EQ(StrTrie::Terminal, trie.find("OKAY"));
        ASSERT_EQ(StrTrie::Terminal, trie.find("YES"));
    }
}
