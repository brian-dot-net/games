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

        TEST_METHOD(ReturnsNextVertices0)
        {
            ReturnsNextVerticesImpl(0, "111111111000");
        }

        TEST_METHOD(ReturnsNextVertices1)
        {
            ReturnsNextVerticesImpl(1, "111111111000");
        }

        TEST_METHOD(ReturnsNextVertices2)
        {
            ReturnsNextVerticesImpl(2, "111111111000");
        }

        TEST_METHOD(ReturnsNextVertices3)
        {
            ReturnsNextVerticesImpl(3, "111111000111");
        }

        TEST_METHOD(ReturnsNextVertices4)
        {
            ReturnsNextVerticesImpl(4, "111111000111");
        }

        TEST_METHOD(ReturnsNextVertices5)
        {
            ReturnsNextVerticesImpl(5, "111111000111");
        }

        TEST_METHOD(ReturnsNextVertices6)
        {
            ReturnsNextVerticesImpl(6, "111000111111");
        }

        TEST_METHOD(ReturnsNextVertices7)
        {
            ReturnsNextVerticesImpl(7, "111000111111");
        }

        TEST_METHOD(ReturnsNextVertices8)
        {
            ReturnsNextVerticesImpl(8, "111000111111");
        }

        TEST_METHOD(ReturnsNextVertices9)
        {
            ReturnsNextVerticesImpl(9, "000111111111");
        }

        TEST_METHOD(ReturnsNextVertices10)
        {
            ReturnsNextVerticesImpl(10, "000111111111");
        }

        TEST_METHOD(ReturnsNextVertices11)
        {
            ReturnsNextVerticesImpl(11, "000111111111");
        }

        TEST_METHOD(FailsNextVerticesOutOfRange12)
        {
            FailsNextVerticesOutOfRangeImpl(12);
        }

        TEST_METHOD(FailsNextVerticesOutOfRange100)
        {
            FailsNextVerticesOutOfRangeImpl(100);
        }

        TEST_METHOD(FailsNextVerticesOutOfRange255)
        {
            FailsNextVerticesOutOfRangeImpl(255);
        }

        TEST_METHOD(StringValue)
        {
            LetterBoxStr box(Init());

            stringstream ss;
            ss << box;

            Assert::AreEqual("ABCDEFGHIJKL", ss.str().c_str());
        }

        TEST_METHOD(InputTooShort)
        {
            Str s;
            s = s + 'A'_c;

            bool didThrow = false;
            try
            {
                LetterBoxStr box(s);
            }
            catch (range_error&)
            {
                didThrow = true;
            }

            Assert::IsTrue(didThrow);
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

        void ReturnsNextVerticesImpl(uint8_t start, const char* expected)
        {
            LetterBoxStr box(Init());

            Vertices verts = box.next(start);

            stringstream ss;
            ss << verts;
            Assert::AreEqual(expected, ss.str().c_str());
        }

        void FailsNextVerticesOutOfRangeImpl(uint8_t start)
        {
            LetterBoxStr box(Init());

            bool didThrow = false;
            try
            {
                box.next(start);
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
