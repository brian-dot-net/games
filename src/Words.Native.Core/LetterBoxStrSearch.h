#pragma once

#include "LetterBoxStr.h"
#include "StrTrie.h"

namespace Words
{
    class LetterBoxStrSearch
    {
    public:
        LetterBoxStrSearch(const StrTrie& trie, LetterBoxStr box);

        template <typename TFound>
        void run(TFound found) const
        {
        }

    private:
        const StrTrie& trie_;
        LetterBoxStr box_;
    };
}