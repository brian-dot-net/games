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
