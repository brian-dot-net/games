#include <iostream>
#include "Sample.h"

using namespace std;
using namespace Words;

int main()
{
    Sample sample(L"world");

    wcout << L"Hello, " << sample.get_Name() << L"!\r\n";

    return 0;
}
