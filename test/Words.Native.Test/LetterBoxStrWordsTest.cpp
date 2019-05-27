#include "CppUnitTest.h"
#include "LetterBoxStrWords.h"
#include <vector>
#include <string>
#include <algorithm>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Words
{
    TEST_CLASS(LetterBoxStrWordsTest)
    {
    public:
        TEST_METHOD(EmptyFindsNothing)
        {
            LetterBoxStrWords words;

            FindSolutions(words, {});
        }

        TEST_METHOD(OneWordFindsNothing)
        {
            LetterBoxStrWords words;
            words.insert("ALE", Vertices(0b100000010001));

            FindSolutions(words, {});
        }

        TEST_METHOD(TwoWordsInvalidSolutionFindsNothing)
        {
            LetterBoxStrWords words;
            words.insert("ALE", Vertices(0b100000010001));
            words.insert("ELF", Vertices(0b100000110000));

            FindSolutions(words, {});
        }

        TEST_METHOD(TwoWordsValidSolutionFindsOne)
        {
            LetterBoxStrWords words;
            words.insert("ADBECF", Vertices(0b000000111111));
            words.insert("FGJHKIL", Vertices(0b111111100000));

            FindSolutions(words, { "ADBECF-FGJHKIL" });
        }

        TEST_METHOD(ManyWordsFindsAllSolutions)
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

    private:
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
            Assert::AreEqual(expected.size(), found.size());
            for (int i = 0; i < found.size(); ++i)
            {
                Assert::AreEqual(foundExpected[i].c_str(), found[i].c_str());
            }
        }
    };
}
