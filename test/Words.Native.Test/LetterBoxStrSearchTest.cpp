#include <gtest/gtest.h>
#include "LetterBoxStrSearch.h"
#include <vector>
#include <bitset>
#include <string>

using namespace std;

namespace Words
{
    LetterBoxStrSearch Init(const StrTrie& trie)
    {
        return LetterBoxStrSearch(trie, LetterBoxStr("ABCDEFGHIJKL"));
    }

    void FindWords(const LetterBoxStrSearch& search, initializer_list<string> expected)
    {
        vector<string> found;
        vector<string> expectedFound(expected);

        search.run([&found](Str w, Vertices v)
            {
                stringstream ss;
                ss << w << ":" << v;
                found.push_back(ss.str());
            });

        ASSERT_EQ(expected.size(), found.size());
        for (int i = 0; i < expected.size(); ++i)
        {
            ASSERT_STREQ(expectedFound[i].c_str(), found[i].c_str());
        }
    }

    TEST(LetterBoxStrSearchTest, EmptyTrieFindsNothing)
    {
        StrTrie trie;
        LetterBoxStrSearch search(Init(trie));

        FindWords(search, {});
    }

    TEST(LetterBoxStrSearchTest, OneValueTrieFindsOneWord)
    {
        StrTrie trie;
        trie.insert("ALE");
        LetterBoxStrSearch search(Init(trie));

        FindWords(search, { "ALE:100000010001" });
    }

    TEST(LetterBoxStrSearchTest, TwelveValueTrieFindsAllWords)
    {
        StrTrie trie;
        trie.insert("ALE");
        trie.insert("BEG");
        trie.insert("CEL");
        trie.insert("DAH");
        trie.insert("ELF");
        trie.insert("FIB");
        trie.insert("GAL");
        trie.insert("HAD");
        trie.insert("ICE");
        trie.insert("JIB");
        trie.insert("KAE");
        trie.insert("LIE");
        LetterBoxStrSearch search(Init(trie));

        FindWords(
            search,
            {
                "ALE:100000010001",
                "BEG:000001010010",
                "CEL:100000010100",
                "DAH:000010001001",
                "ELF:100000110000",
                "FIB:000100100010",
                "GAL:100001000001",
                "HAD:000010001001",
                "ICE:000100010100",
                "JIB:001100000010",
                "KAE:010000010001",
                "LIE:100100010000"
            });
    }

    TEST(LetterBoxStrSearchTest, SearchDoesNotReturnInvalidMoves)
    {
        StrTrie trie;
        trie.insert("ABC");
        trie.insert("DEF");
        trie.insert("GHI");
        trie.insert("JKL");
        trie.insert("MOW");
        trie.insert("ALA");
        LetterBoxStrSearch search(Init(trie));

        FindWords(search, { "ALA:100000000001" });
    }

    TEST(LetterBoxStrSearchTest, SearchDoesNotAttemptToBuildTooLongWords)
    {
        StrTrie trie;
        trie.insert("LA");
        trie.insert("LALA");
        trie.insert("LALALA");
        trie.insert("LALALALA");
        trie.insert("LALALALALA");
        trie.insert("LALALALALALA");
        LetterBoxStrSearch search(Init(trie));

        FindWords(
            search,
            {
                "LA:100000000001",
                "LALA:100000000001",
                "LALALA:100000000001",
                "LALALALA:100000000001",
                "LALALALALA:100000000001",
                "LALALALALALA:100000000001"
            });
    }
}
