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
    };
}
