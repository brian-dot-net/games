#include "Stopwatch.h"

using namespace std::chrono;
using namespace Words;

steady_clock::time_point now()
{
    return high_resolution_clock::now();
}

Stopwatch::Stopwatch()
    : start_(now())
{
}

float Stopwatch::elapsed() const
{
    long long ns = (now() - start_).count();
    return ns / 1000000000.0f;
}