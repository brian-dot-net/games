#include "CppUnitTest.h"
#include "Hashtable.h"
#include <string>
#include <sstream>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Words
{
    TEST_CLASS(HashtableTest)
    {
    public:
        TEST_METHOD(EmptyTableFindsNothing)
        {
            Hashtable<string, int> table;

            int v;
            bool found = table.get("not-here", v);

            Assert::IsFalse(found);
        }

        TEST_METHOD(OneEntryTableKeyNotFound)
        {
            Hashtable<string, int> table;

            table.insert("here", 11);
            int v;
            bool found = table.get("not-here", v);

            Assert::IsFalse(found);
        }

        TEST_METHOD(OneEntryTableKeyFound)
        {
            Hashtable<string, int> table;

            table.insert("here", 11);
            int v = 0;
            bool found = table.get("here", v);

            Assert::IsTrue(found);
            Assert::AreEqual(11, v);
        }

        TEST_METHOD(OneEntryTableKeyReplaced)
        {
            Hashtable<string, int> table;

            bool first = table.insert("overwrite", 10);
            bool second = table.insert("overwrite", 100);
            int v = 0;
            bool found = table.get("overwrite", v);

            Assert::IsTrue(first);
            Assert::IsFalse(second);
            Assert::IsTrue(found);
            Assert::AreEqual(100, v);
        }

        TEST_METHOD(InsertManyEntriesResize)
        {
            const int Size = 1000;
            Hashtable<string, int> table;

            for (int i = 1; i <= Size; ++i)
            {
                stringstream s;
                s << "k" << i;
                string key(s.str());
                bool inserted = table.insert(key, i);
                Assert::IsTrue(inserted);
            }

            for (int i = 1; i <= Size; ++i)
            {
                stringstream s;
                s << "k" << i;
                string key(s.str());
                int v = 0;
                bool found = table.get(key, v);
                Assert::IsTrue(found);
                Assert::AreEqual(i, v);
            }

            for (int i = 1; i <= Size; ++i)
            {
                stringstream s;
                s << "k" << i;
                string key(s.str());
                bool inserted = table.insert(key, i * 2);
                Assert::IsFalse(inserted);
            }

            for (int i = 1; i <= Size; ++i)
            {
                stringstream s;
                s << "k" << i;
                string key(s.str());
                int v = 0;
                bool found = table.get(key, v);
                Assert::IsTrue(found);
                Assert::AreEqual(i * 2, v);
            }
        }
    };
}
