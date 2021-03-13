#include <gtest/gtest.h>
#include "LetterBoxStr.h"

using namespace std;

namespace Words
{
    LetterBoxStr Init()
    {
        return LetterBoxStr("ABCDEFGHIJKL");
    }

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

        ASSERT_TRUE(didThrow);
    }

    void ReturnsNextVerticesImpl(uint8_t start, const char* expected)
    {
        LetterBoxStr box(Init());

        Vertices verts = box.next(start);

        stringstream ss;
        ss << verts;
        ASSERT_STREQ(expected, ss.str().c_str());
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

        ASSERT_TRUE(didThrow);
    }

    TEST(LetterBoxStrTest, AllowsCharLookup)
    {
        LetterBoxStr box(Init());

        ASSERT_EQ('A'_c, box[0]);
        ASSERT_EQ('B'_c, box[1]);
        ASSERT_EQ('C'_c, box[2]);
        ASSERT_EQ('D'_c, box[3]);
        ASSERT_EQ('E'_c, box[4]);
        ASSERT_EQ('F'_c, box[5]);
        ASSERT_EQ('G'_c, box[6]);
        ASSERT_EQ('H'_c, box[7]);
        ASSERT_EQ('I'_c, box[8]);
        ASSERT_EQ('J'_c, box[9]);
        ASSERT_EQ('K'_c, box[10]);
        ASSERT_EQ('L'_c, box[11]);
    }

    TEST(LetterBoxStrTest, FailsCharLookupOutOfRange12)
    {
        FailsCharLookupOutOfRangeImpl(12);
    }

    TEST(LetterBoxStrTest, FailsCharLookupOutOfRange255)
    {
        FailsCharLookupOutOfRangeImpl(255);
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices0)
    {
        ReturnsNextVerticesImpl(0, "111111111000");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices1)
    {
        ReturnsNextVerticesImpl(1, "111111111000");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices2)
    {
        ReturnsNextVerticesImpl(2, "111111111000");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices3)
    {
        ReturnsNextVerticesImpl(3, "111111000111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices4)
    {
        ReturnsNextVerticesImpl(4, "111111000111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices5)
    {
        ReturnsNextVerticesImpl(5, "111111000111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices6)
    {
        ReturnsNextVerticesImpl(6, "111000111111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices7)
    {
        ReturnsNextVerticesImpl(7, "111000111111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices8)
    {
        ReturnsNextVerticesImpl(8, "111000111111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices9)
    {
        ReturnsNextVerticesImpl(9, "000111111111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices10)
    {
        ReturnsNextVerticesImpl(10, "000111111111");
    }

    TEST(LetterBoxStrTest, ReturnsNextVertices11)
    {
        ReturnsNextVerticesImpl(11, "000111111111");
    }

    TEST(LetterBoxStrTest, FailsNextVerticesOutOfRange12)
    {
        FailsNextVerticesOutOfRangeImpl(12);
    }

    TEST(LetterBoxStrTest, FailsNextVerticesOutOfRange100)
    {
        FailsNextVerticesOutOfRangeImpl(100);
    }

    TEST(LetterBoxStrTest, FailsNextVerticesOutOfRange255)
    {
        FailsNextVerticesOutOfRangeImpl(255);
    }

    TEST(LetterBoxStrTest, StringValue)
    {
        LetterBoxStr box(Init());

        stringstream ss;
        ss << box;

        ASSERT_STREQ("ABCDEFGHIJKL", ss.str().c_str());
    }

    TEST(LetterBoxStrTest, InputTooShort)
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

        ASSERT_TRUE(didThrow);
    }
}
