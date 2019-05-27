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
            for (uint8_t v1 = 0; v1 < 12; ++v1)
            {
                Ch c = box_[v1];
                Vertices verts(static_cast<uint16_t>(1 << v1));
                Str str;
                next(str + c, v1, verts, found);
            }
        }

    private:
        const StrTrie& trie_;
        LetterBoxStr box_;

        template <typename TFound>
        void next(Str str, uint8_t v1, Vertices verts, TFound found) const
        {
            StrTrie::NodeKind kind = trie_.find(str);
            if (kind == StrTrie::None)
            {
                return;
            }

            if (kind == StrTrie::Terminal)
            {
                found(str, verts);
            }

            if (str.length() == 12)
            {
                return;
            }

            Vertices nextMoves = box_.next(v1);
            for (uint8_t v2 = 0; v2 < 12; ++v2)
            {
                if (nextMoves[v2])
                {
                    Ch c = box_[v2];
                    Vertices nextVerts(static_cast<uint16_t>(1 << v2));
                    nextVerts |= verts;
                    next(str + c, v2, nextVerts, found);
                }
            }
        }
    };
}