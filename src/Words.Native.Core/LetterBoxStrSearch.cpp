#include "LetterBoxStrSearch.h"

using namespace std;
using namespace Words;

LetterBoxStrSearch::LetterBoxStrSearch(const StrTrie& trie, LetterBoxStr box)
    : trie_(trie),
    box_(box)
{
}