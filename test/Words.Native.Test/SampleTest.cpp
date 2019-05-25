#include "CppUnitTest.h"
#include "Sample.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Words
{
    TEST_CLASS(SampleTest)
    {
    public:
        TEST_METHOD(TestMethod1)
        {
            Sample sample(L"hello");

            const wstring& name = sample.get_Name();

            Assert::AreEqual(L"hello", name.c_str());
        }
    };
}
