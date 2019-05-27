#pragma once

#include "Str.h"
#include "Vertices.h"

namespace Words
{
    class LetterBoxStr
    {
    public:
        LetterBoxStr(const Str& box);

        Ch operator[](uint8_t index) const;

        Vertices next(uint8_t start) const;

        friend std::ostream& operator<<(std::ostream& os, const LetterBoxStr& s);

    private:
        Str box_;
    };

    std::ostream& operator<<(std::ostream& os, const LetterBoxStr& s);
}