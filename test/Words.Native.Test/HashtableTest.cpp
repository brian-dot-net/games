#include "CppUnitTest.h"
#include "Hashtable.h"
#include <string>

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
    };
}
