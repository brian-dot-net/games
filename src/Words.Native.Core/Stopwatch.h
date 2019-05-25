#pragma once

#include <chrono>

namespace Words
{
    class Stopwatch
    {
    public:
        Stopwatch();

        float elapsed() const;

    private:
        std::chrono::steady_clock::time_point start_;
    };
}