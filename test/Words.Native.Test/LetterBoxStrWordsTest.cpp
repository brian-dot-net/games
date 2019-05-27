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
