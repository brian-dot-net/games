#pragma once

#include <string>
#include <iostream>

namespace Words
{
    typedef uint8_t Ch;

    class Str
    {
    public:
        Str();

        uint8_t length() const;

        Ch operator[](uint8_t index) const;
    };

    std::ostream& operator<<(std::ostream& os, const Str& s);

    constexpr Ch operator "" _c(char c)
    {
        return 0;
    }
}