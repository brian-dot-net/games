#include <gtest/gtest.h>
#include "Str.h"
#include <unordered_set>
#include <unordered_map>

using namespace std;

namespace Words
{
    void StrValue(const Str& s, const char* str)
    {
        stringstream ss;
        ss << s;
        ASSERT_STREQ(str, s.str().c_str());
        ASSERT_STREQ(str, ss.str().c_str());
        ASSERT_EQ(uint8_t(strnlen_s(str, 12)), s.length());
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
        ASSERT_EQ(c0, s[0]);
        ASSERT_EQ(c1, s[1]);
        ASSERT_EQ(c2, s[2]);
        ASSERT_EQ(c3, s[3]);
        ASSERT_EQ(c4, s[4]);
        ASSERT_EQ(c5, s[5]);
        ASSERT_EQ(c6, s[6]);
        ASSERT_EQ(c7, s[7]);
        ASSERT_EQ(c8, s[8]);
        ASSERT_EQ(c9, s[9]);
        ASSERT_EQ(c10, s[10]);
        ASSERT_EQ(c11, s[11]);
    }

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
        catch (range_error&)
        {
            didThrow = true;
        }

        ASSERT_TRUE(didThrow);
    }

    void TestEquals(const Str& x, const Str& y, bool expected)
    {
        ASSERT_EQ(expected, x == y);
        ASSERT_EQ(expected, y == x);
    }

    void ParseFromStringImpl(const char* expected)
    {
        Str s = expected;

        StrValue(s, expected);
    }

    TEST(StrTest, Empty)
    {
        Str s;

        StrValue(s, "");
        CharValues(s);
    }

    TEST(StrTest, OneCharA)
    {
        OneCharImpl('A'_c, "A");
    }

    TEST(StrTest, OneCharB)
    {
        OneCharImpl('B'_c, "B");
    }

    TEST(StrTest, OneCharC)
    {
        OneCharImpl('C'_c, "C");
    }

    TEST(StrTest, TwoCharsDE)
    {
        TwoCharsImpl('D'_c, 'E'_c, "DE");
    }

    TEST(StrTest, TwoCharsFG)
    {
        TwoCharsImpl('F'_c, 'G'_c, "FG");
    }

    TEST(StrTest, TwoCharsHI)
    {
        TwoCharsImpl('H'_c, 'I'_c, "HI");
    }

    TEST(StrTest, FourCharsJKLM)
    {
        FourCharsImpl('J'_c, 'K'_c, 'L'_c, 'M'_c, "JKLM");
    }

    TEST(StrTest, FourCharsNOPQ)
    {
        FourCharsImpl('N'_c, 'O'_c, 'P'_c, 'Q'_c, "NOPQ");
    }

    TEST(StrTest, FourCharsRSTU)
    {
        FourCharsImpl('R'_c, 'S'_c, 'T'_c, 'U'_c, "RSTU");
    }

    TEST(StrTest, EightCharsVWXYZABC)
    {
        EightCharsImpl('V'_c, 'W'_c, 'X'_c, 'Y'_c, 'Z'_c, 'A'_c, 'B'_c, 'C'_c, "VWXYZABC");
    }

    TEST(StrTest, EightCharsABCDEFGH)
    {
        EightCharsImpl('A'_c, 'B'_c, 'C'_c, 'D'_c, 'E'_c, 'F'_c, 'G'_c, 'H'_c, "ABCDEFGH");
    }

    TEST(StrTest, EightCharsIJKLMNOP)
    {
        EightCharsImpl('I'_c, 'J'_c, 'K'_c, 'L'_c, 'M'_c, 'N'_c, 'O'_c, 'P'_c, "IJKLMNOP");
    }

    TEST(StrTest, TwelveCharsQRSTUVWXYZAB)
    {
        TwelveCharsImpl('Q'_c, 'R'_c, 'S'_c, 'T'_c, 'U'_c, 'V'_c, 'W'_c, 'X'_c, 'Y'_c, 'Z'_c, 'A'_c, 'B'_c, "QRSTUVWXYZAB");
    }

    TEST(StrTest, TwelveCharsCDEFGHIJKLMN)
    {
        TwelveCharsImpl('C'_c, 'D'_c, 'E'_c, 'F'_c, 'G'_c, 'H'_c, 'I'_c, 'J'_c, 'K'_c, 'L'_c, 'M'_c, 'N'_c, "CDEFGHIJKLMN");
    }

    TEST(StrTest, TwelveCharsOPQRSTUVWXYZ)
    {
        TwelveCharsImpl('O'_c, 'P'_c, 'Q'_c, 'R'_c, 'S'_c, 'T'_c, 'U'_c, 'V'_c, 'W'_c, 'X'_c, 'Y'_c, 'Z'_c, "OPQRSTUVWXYZ");
    }

    TEST(StrTest, AppendTooMany)
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
        catch (range_error&)
        {
            didThrow = true;
        }

        ASSERT_TRUE(didThrow);
    }

    TEST(StrTest, IndexTooBig12)
    {
        IndexTooBigImpl(12);
    }

    TEST(StrTest, IndexTooBig100)
    {
        IndexTooBigImpl(100);
    }

    TEST(StrTest, IndexTooBig255)
    {
        IndexTooBigImpl(255);
    }

    TEST(StrTest, ChopEmpty)
    {
        Str s;

        bool didThrow = false;
        try
        {
            s.chop();
        }
        catch (range_error&)
        {
            didThrow = true;
        }

        ASSERT_TRUE(didThrow);
    }

    TEST(StrTest, ChopChars)
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

        Str t = s.chop();
        StrValue(t, "ABCDEFGHIJK");

        t = t.chop();
        StrValue(t, "ABCDEFGHIJ");

        t = t.chop();
        StrValue(t, "ABCDEFGHI");

        t = t.chop();
        StrValue(t, "ABCDEFGH");

        t = t.chop();
        StrValue(t, "ABCDEFG");

        t = t.chop();
        StrValue(t, "ABCDEF");

        t = t.chop();
        StrValue(t, "ABCDE");

        t = t.chop();
        StrValue(t, "ABCD");

        t = t.chop();
        StrValue(t, "ABC");

        t = t.chop();
        StrValue(t, "AB");

        t = t.chop();
        StrValue(t, "A");

        t = t.chop();
        StrValue(t, "");
    }

    TEST(StrTest, Equality)
    {
        Str empty;
        Str a = empty + 'A'_c;
        Str b = empty + 'B'_c;
        Str ab = empty + 'A'_c + 'B'_c;
        Str ba = empty + 'B'_c + 'A'_c;
        Str cdefgh = empty + 'C'_c + 'D'_c + 'E'_c + 'F'_c + 'G'_c + 'H'_c;

        TestEquals(empty, a, false);
        TestEquals(empty, empty, true);
        TestEquals(a, a, true);
        TestEquals(a, b, false);
        TestEquals(ab, ba, false);
        TestEquals(ba, ba, true);
        TestEquals(cdefgh, ba, false);
        TestEquals(cdefgh, cdefgh, true);
    }

    TEST(StrTest, HashCode)
    {
        Str empty;
        Str a = empty + 'A'_c;
        Str b = empty + 'B'_c;
        Str ab = empty + 'A'_c + 'B'_c;
        Str ba = empty + 'B'_c + 'A'_c;
        Str cdefgh = empty + 'C'_c + 'D'_c + 'E'_c + 'F'_c + 'G'_c + 'H'_c;

        unordered_set<size_t> codes;
        codes.insert(empty.hash_code());
        codes.insert(a.hash_code());
        codes.insert(b.hash_code());
        codes.insert(ab.hash_code());
        codes.insert(ba.hash_code());
        codes.insert(cdefgh.hash_code());

        ASSERT_EQ(size_t(6), codes.size());
    }

    TEST(StrTest, MapKey)
    {
        Str empty;
        Str a = empty + 'A'_c;
        Str b = empty + 'B'_c;
        Str ab = empty + 'A'_c + 'B'_c;
        Str ba = empty + 'B'_c + 'A'_c;
        Str cdefgh = empty + 'C'_c + 'D'_c + 'E'_c + 'F'_c + 'G'_c + 'H'_c;
        unordered_map<Str, const char*> map;

        map.insert(make_pair(empty, ""));
        map.insert(make_pair(a, "a"));
        map.insert(make_pair(b, "b"));
        map.insert(make_pair(ab, "ab"));
        map.insert(make_pair(ba, "ba"));
        map.insert(make_pair(cdefgh, "cdefgh"));

        ASSERT_EQ(size_t(6), map.size());
        ASSERT_STREQ("a", map[a]);
        ASSERT_STREQ("b", map[b]);
        ASSERT_STREQ("ab", map[ab]);
        ASSERT_STREQ("ba", map[ba]);
        ASSERT_STREQ("cdefgh", map[cdefgh]);
    }

    TEST(StrTest, ParseFromStringEmpty)
    {
        ParseFromStringImpl("");
    }

    TEST(StrTest, ParseFromStringA)
    {
        ParseFromStringImpl("A");
    }

    TEST(StrTest, ParseFromStringBC)
    {
        ParseFromStringImpl("BC");
    }

    TEST(StrTest, ParseFromStringDEF)
    {
        ParseFromStringImpl("DEF");
    }

    TEST(StrTest, ParseFromStringGHIJ)
    {
        ParseFromStringImpl("GHIJ");
    }

    TEST(StrTest, ParseFromStringKLMNO)
    {
        ParseFromStringImpl("KLMNO");
    }

    TEST(StrTest, ParseFromStringPQRSTU)
    {
        ParseFromStringImpl("PQRSTU");
    }

    TEST(StrTest, ParseFromStringVWXYZAB)
    {
        ParseFromStringImpl("VWXYZAB");
    }

    TEST(StrTest, ParseFromStringCDEFGHIJ)
    {
        ParseFromStringImpl("CDEFGHIJ");
    }

    TEST(StrTest, ParseFromStringKLMNOPQRS)
    {
        ParseFromStringImpl("KLMNOPQRS");
    }

    TEST(StrTest, ParseFromStringTUVWXYZABC)
    {
        ParseFromStringImpl("TUVWXYZABC");
    }

    TEST(StrTest, ParseFromStringDEFGHIJKLMN)
    {
        ParseFromStringImpl("DEFGHIJKLMN");
    }

    TEST(StrTest, ParseFromStringOPQRSTUVWXYZ)
    {
        ParseFromStringImpl("OPQRSTUVWXYZ");
    }
}
