#include "CppUnitTest.h"
#include "LetterBoxStr.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Words
{
    TEST_CLASS(LetterBoxStrTest)
    {
    public:
        TEST_METHOD(AllowsCharLookup)
        {
            LetterBoxStr box(Init());

            Assert::AreEqual('A'_c, box[0]);
            Assert::AreEqual('B'_c, box[1]);
            Assert::AreEqual('C'_c, box[2]);
            Assert::AreEqual('D'_c, box[3]);
            Assert::AreEqual('E'_c, box[4]);
            Assert::AreEqual('F'_c, box[5]);
            Assert::AreEqual('G'_c, box[6]);
            Assert::AreEqual('H'_c, box[7]);
            Assert::AreEqual('I'_c, box[8]);
            Assert::AreEqual('J'_c, box[9]);
            Assert::AreEqual('K'_c, box[10]);
            Assert::AreEqual('L'_c, box[11]);
        }

        TEST_METHOD(FailsCharLookupOutOfRange12)
        {
            FailsCharLookupOutOfRangeImpl(12);
        }

        TEST_METHOD(FailsCharLookupOutOfRange255)
        {
            FailsCharLookupOutOfRangeImpl(255);
        }

    private:
        void FailsCharLookupOutOfRangeImpl(uint8_t index)
        {
            LetterBoxStr box(Init());

            bool didThrow = false;
            try
            {
                box[index];
            }
            catch (range_error&)
            {
                didThrow = true;
            }

            Assert::IsTrue(didThrow);
        }

        LetterBoxStr Init()
        {
            return LetterBoxStr("ABCDEFGHIJKL");
        }
    };
}
