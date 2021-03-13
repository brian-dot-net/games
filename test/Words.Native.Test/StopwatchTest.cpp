#include <gtest/gtest.h>
#include "Stopwatch.h"
#include <chrono>
#include <thread>

using namespace std;
using namespace std::chrono;

namespace Words
{
    TEST(StopwatchTest, GetsElapsedTime)
    {
        Stopwatch watch;

        this_thread::sleep_for(milliseconds(1));
        float secs = watch.elapsed();

        ASSERT_TRUE(secs > 0.0f);
    }
}
