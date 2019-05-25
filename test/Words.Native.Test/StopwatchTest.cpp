#include "CppUnitTest.h"
#include "Stopwatch.h"
#include <chrono>
#include <thread>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;
using namespace std::chrono;

namespace Words
{
    TEST_CLASS(StopwatchTest)
    {
    public:
        TEST_METHOD(GetsElapsedTime)
        {
            Stopwatch watch;

            this_thread::sleep_for(milliseconds(1));
            float secs = watch.elapsed();

            Assert::IsTrue(secs > 0.0f);
        }
    };
}
