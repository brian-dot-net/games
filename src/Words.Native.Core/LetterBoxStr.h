#pragma once

#include "Str.h"

namespace Words
{
    class LetterBoxStr
    {
    public:
        LetterBoxStr(const Str& box);

        Ch operator[](uint8_t index) const;

    private:
        Str box_;
    };
}