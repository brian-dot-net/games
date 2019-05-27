#pragma once

#include "Str.h"
#include "Vertices.h"

namespace Words
{
    class LetterBoxStrWords
    {
    public:
        LetterBoxStrWords();

        void insert(Str word, Vertices verts);

        template <typename TFound>
        void find(TFound found) const
        {
        }

    private:
    };
}