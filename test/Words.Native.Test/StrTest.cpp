#include "CppUnitTest.h"
#include "Str.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Words
{
    TEST_CLASS(StrTest)
    {
    public:
        TEST_METHOD(Empty)
        {
            Str s;

            StrValue(s, "");
            CharValues(s);
        }

        TEST_METHOD(OneCharA)
        {
            OneCharImpl('A'_c, "A");
        }

        TEST_METHOD(OneCharB)
        {
            OneCharImpl('B'_c, "B");
        }

        TEST_METHOD(OneCharC)
        {
            OneCharImpl('C'_c, "C");
        }

        TEST_METHOD(TwoCharsDE)
        {
            TwoCharsImpl('D'_c, 'E'_c, "DE");
        }

        TEST_METHOD(TwoCharsFG)
        {
            TwoCharsImpl('F'_c, 'G'_c, "FG");
        }

        TEST_METHOD(TwoCharsHI)
        {
            TwoCharsImpl('H'_c, 'I'_c, "HI");
        }

        TEST_METHOD(FourCharsJKLM)
        {
            FourCharsImpl('J'_c, 'K'_c, 'L'_c, 'M'_c, "JKLM");
        }

        TEST_METHOD(FourCharsNOPQ)
        {
            FourCharsImpl('N'_c, 'O'_c, 'P'_c, 'Q'_c, "NOPQ");
        }

        TEST_METHOD(FourCharsRSTU)
        {
            FourCharsImpl('R'_c, 'S'_c, 'T'_c, 'U'_c, "RSTU");
        }

        TEST_METHOD(EightCharsVWXYZABC)
        {
            EightCharsImpl('V'_c, 'W'_c, 'X'_c, 'Y'_c, 'Z'_c, 'A'_c, 'B'_c, 'C'_c, "VWXYZABC");
        }

        TEST_METHOD(EightCharsABCDEFGH)
        {
            EightCharsImpl('A'_c, 'B'_c, 'C'_c, 'D'_c, 'E'_c, 'F'_c, 'G'_c, 'H'_c, "ABCDEFGH");
        }

        TEST_METHOD(EightCharsIJKLMNOP)
        {
            EightCharsImpl('I'_c, 'J'_c, 'K'_c, 'L'_c, 'M'_c, 'N'_c, 'O'_c, 'P'_c, "IJKLMNOP");
        }

        TEST_METHOD(TwelveCharsQRSTUVWXYZAB)
        {
            TwelveCharsImpl('Q'_c, 'R'_c, 'S'_c, 'T'_c, 'U'_c, 'V'_c, 'W'_c, 'X'_c, 'Y'_c, 'Z'_c, 'A'_c, 'B'_c, "QRSTUVWXYZAB");
        }

        TEST_METHOD(TwelveCharsCDEFGHIJKLMN)
        {
            TwelveCharsImpl('C'_c, 'D'_c, 'E'_c, 'F'_c, 'G'_c, 'H'_c, 'I'_c, 'J'_c, 'K'_c, 'L'_c, 'M'_c, 'N'_c, "CDEFGHIJKLMN");
        }

        TEST_METHOD(TwelveCharsOPQRSTUVWXYZ)
        {
            TwelveCharsImpl('O'_c, 'P'_c, 'Q'_c, 'R'_c, 'S'_c, 'T'_c, 'U'_c, 'V'_c, 'W'_c, 'X'_c, 'Y'_c, 'Z'_c, "OPQRSTUVWXYZ");
        }

        TEST_METHOD(AppendTooMany)
        {
            Str s;
            s = s + 'A'_c;
            s = s + 'B'_c;
            s = s + 'C'_c;
            s = s + 'D'_c;
            s = s + 'E'_c;
            s = s + 'F'_c;
            s = s + 'G'_c;
            s = s + 'H'_c;
            s = s + 'I'_c;
            s = s + 'J'_c;
            s = s + 'K'_c;
            s = s + 'L'_c;

            bool didThrow = false;
            try
            {
                s + 'K'_c;
            }
            catch (range_error& e)
            {
                didThrow = true;
            }

            Assert::IsTrue(didThrow);
        }

        TEST_METHOD(IndexTooBig12)
        {
            IndexTooBigImpl(12);
        }

        TEST_METHOD(IndexTooBig100)
        {
            IndexTooBigImpl(100);
        }

        TEST_METHOD(IndexTooBig255)
        {
            IndexTooBigImpl(255);
        }

        TEST_METHOD(ChopEmpty)
        {
            Str s;

            bool didThrow = false;
            try
            {
                s.chop();
            }
            catch (range_error& e)
            {
                didThrow = true;
            }

            Assert::IsTrue(didThrow);
        }

    private:
        void OneCharImpl(Ch c0, const char* str)
        {
            Str s;
            s = s + c0;

            StrValue(s, str);
            CharValues(s, c0);
        }

        void TwoCharsImpl(Ch c0, Ch c1, const char* str)
        {
            Str s;
            s = s + c0;
            s = s + c1;

            StrValue(s, str);
            CharValues(s, c0, c1);
        }

        void FourCharsImpl(Ch c0, Ch c1, Ch c2, Ch c3, const char* str)
        {
            Str s;
            s = s + c0;
            s = s + c1;
            s = s + c2;
            s = s + c3;

            StrValue(s, str);
            CharValues(s, c0, c1, c2, c3);
        }

        void EightCharsImpl(Ch c0, Ch c1, Ch c2, Ch c3, Ch c4, Ch c5, Ch c6, Ch c7, const char* str)
        {
            Str s;
            s = s + c0;
            s = s + c1;
            s = s + c2;
            s = s + c3;
            s = s + c4;
            s = s + c5;
            s = s + c6;
            s = s + c7;

            StrValue(s, str);
            CharValues(s, c0, c1, c2, c3, c4, c5, c6, c7);
        }

        void TwelveCharsImpl(Ch c0, Ch c1, Ch c2, Ch c3, Ch c4, Ch c5, Ch c6, Ch c7, Ch c8, Ch c9, Ch c10, Ch c11, const char* str)
        {
            Str s;
            s = s + c0;
            s = s + c1;
            s = s + c2;
            s = s + c3;
            s = s + c4;
            s = s + c5;
            s = s + c6;
            s = s + c7;
            s = s + c8;
            s = s + c9;
            s = s + c10;
            s = s + c11;

            StrValue(s, str);
            CharValues(s, c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11);
        }

        void IndexTooBigImpl(uint8_t index)
        {
            Str s;
            s = s + 'A'_c;
            s = s + 'B'_c;
            s = s + 'C'_c;
            s = s + 'D'_c;
            s = s + 'E'_c;
            s = s + 'F'_c;
            s = s + 'G'_c;
            s = s + 'H'_c;
            s = s + 'I'_c;
            s = s + 'J'_c;
            s = s + 'K'_c;
            s = s + 'L'_c;

            bool didThrow = false;
            try
            {
                s[index];
            }
            catch (range_error& e)
            {
                didThrow = true;
            }

            Assert::IsTrue(didThrow);
        }

        void StrValue(const Str& s, const char* str)
        {
            stringstream ss;
            ss << s;
            Assert::AreEqual(str, ss.str().c_str());
            Assert::AreEqual(uint8_t(strnlen_s(str, 12)), s.length());
        }

        void CharValues(
            Str s,
            Ch c0 = '\0'_c,
            Ch c1 = '\0'_c,
            Ch c2 = '\0'_c,
            Ch c3 = '\0'_c,
            Ch c4 = '\0'_c,
            Ch c5 = '\0'_c,
            Ch c6 = '\0'_c,
            Ch c7 = '\0'_c,
            Ch c8 = '\0'_c,
            Ch c9 = '\0'_c,
            Ch c10 = '\0'_c,
            Ch c11 = '\0'_c)
        {
            Assert::AreEqual(c0, s[0]);
            Assert::AreEqual(c1, s[1]);
            Assert::AreEqual(c2, s[2]);
            Assert::AreEqual(c3, s[3]);
            Assert::AreEqual(c4, s[4]);
            Assert::AreEqual(c5, s[5]);
            Assert::AreEqual(c6, s[6]);
            Assert::AreEqual(c7, s[7]);
            Assert::AreEqual(c8, s[8]);
            Assert::AreEqual(c9, s[9]);
            Assert::AreEqual(c10, s[10]);
            Assert::AreEqual(c11, s[11]);
        }
    };
}
