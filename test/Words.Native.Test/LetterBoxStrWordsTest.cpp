#include <gtest/gtest.h>
#include "LetterBoxStrWords.h"
#include <vector>
#include <string>
#include <algorithm>

using namespace std;

namespace Words
{
    void FindSolutions(const LetterBoxStrWords& words, initializer_list<string> expected)
    {
        vector<string> found;
        vector<string> foundExpected(expected);

        words.find([&found](Str w1, Str w2)
            {
                stringstream ss;
                ss << w1 << "-" << w2;
                found.push_back(ss.str());
            });

        sort(found.begin(), found.end());
        ASSERT_EQ(expected.size(), found.size());
        for (int i = 0; i < found.size(); ++i)
        {
            ASSERT_STREQ(foundExpected[i].c_str(), found[i].c_str());
        }
    }

    TEST(LetterBoxStrWordsTest, EmptyFindsNothing)
    {
        LetterBoxStrWords words;

        FindSolutions(words, {});
    }

    TEST(LetterBoxStrWordsTest, OneWordFindsNothing)
    {
        LetterBoxStrWords words;
        words.insert("ALE", Vertices(0b100000010001));

        FindSolutions(words, {});
    }

    TEST(LetterBoxStrWordsTest, TwoWordsInvalidSolutionFindsNothing)
    {
        LetterBoxStrWords words;
        words.insert("ALE", Vertices(0b100000010001));
        words.insert("ELF", Vertices(0b100000110000));

        FindSolutions(words, {});
    }

    TEST(LetterBoxStrWordsTest, TwoWordsValidSolutionFindsOne)
    {
        LetterBoxStrWords words;
        words.insert("ADBECF", Vertices(0b000000111111));
        words.insert("FGJHKIL", Vertices(0b111111100000));

        FindSolutions(words, { "ADBECF-FGJHKIL" });
    }

    TEST(LetterBoxStrWordsTest, ManyWordsFindsAllSolutions)
    {
        LetterBoxStrWords words;
        words.insert("ADB", Vertices(0b000000001011));
        words.insert("ADBECF", Vertices(0b000000111111));
        words.insert("BECFHJGKIL", Vertices(0b111111111110));
        words.insert("FGJHKIL", Vertices(0b111111100000));
        words.insert("FAHKILJG", Vertices(0b111111100001));
        words.insert("FAHKILJ", Vertices(0b111110100001));

        FindSolutions(words, { "ADB-BECFHJGKIL", "ADBECF-FAHKILJG", "ADBECF-FGJHKIL" });
    }

    TEST(LetterBoxStrWordsTest, CountsWords)
    {
        LetterBoxStrWords words;

        ASSERT_EQ(size_t(0), words.size());

        words.insert("AB", Vertices());

        ASSERT_EQ(size_t(1), words.size());

        words.insert("AB", Vertices());

        ASSERT_EQ(size_t(1), words.size());

        words.insert("ABC", Vertices());

        ASSERT_EQ(size_t(2), words.size());

        words.insert("ABCD", Vertices());

        ASSERT_EQ(size_t(3), words.size());
    }
}
