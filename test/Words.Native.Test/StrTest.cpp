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

            stringstream ss;
            ss << s;

            Assert::AreEqual(uint8_t(0), s.length());
            Assert::AreEqual("", ss.str().c_str());
            Assert::AreEqual('\0'_c, s[0]);
            Assert::AreEqual('\0'_c, s[1]);
            Assert::AreEqual('\0'_c, s[2]);
            Assert::AreEqual('\0'_c, s[3]);
            Assert::AreEqual('\0'_c, s[4]);
            Assert::AreEqual('\0'_c, s[5]);
            Assert::AreEqual('\0'_c, s[6]);
            Assert::AreEqual('\0'_c, s[7]);
            Assert::AreEqual('\0'_c, s[8]);
            Assert::AreEqual('\0'_c, s[9]);
            Assert::AreEqual('\0'_c, s[10]);
            Assert::AreEqual('\0'_c, s[11]);
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

    private:
        void OneCharImpl(Ch c, const char* str)
        {
            Str s;
            s = s + c;

            stringstream ss;
            ss << s;

            Assert::AreEqual(uint8_t(1), s.length());
            Assert::AreEqual(str, ss.str().c_str());
            Assert::AreEqual(c, s[0]);
            Assert::AreEqual('\0'_c, s[1]);
            Assert::AreEqual('\0'_c, s[2]);
            Assert::AreEqual('\0'_c, s[3]);
            Assert::AreEqual('\0'_c, s[4]);
            Assert::AreEqual('\0'_c, s[5]);
            Assert::AreEqual('\0'_c, s[6]);
            Assert::AreEqual('\0'_c, s[7]);
            Assert::AreEqual('\0'_c, s[8]);
            Assert::AreEqual('\0'_c, s[9]);
            Assert::AreEqual('\0'_c, s[10]);
            Assert::AreEqual('\0'_c, s[11]);
        }
    };
}
