cmake_minimum_required(VERSION 3.17)
project(games LANGUAGES CXX)

include(GoogleTest)
find_package(GTest)

add_library(Words.Native.Core
    src/Words.Native.Core/LetterBoxStr.cpp
    src/Words.Native.Core/LetterBoxStrSearch.cpp
    src/Words.Native.Core/LetterBoxStrWords.cpp
    src/Words.Native.Core/Stopwatch.cpp
    src/Words.Native.Core/Str.cpp
    src/Words.Native.Core/StrTrie.cpp
)

target_include_directories(Words.Native.Core
    PUBLIC
        ${CMAKE_CURRENT_SOURCE_DIR}/src/Words.Native.Core
)

add_executable(Words.Benchmark.Native
    src/Words.Benchmark.Native/Main.cpp
)

target_link_libraries(Words.Benchmark.Native
    Words.Native.Core
)

add_executable(LetterBoxedSolver.Native
    src/LetterBoxedSolver.Native/LetterBoxedSolver.cpp
)

target_link_libraries(LetterBoxedSolver.Native
    Words.Native.Core
)

add_executable(Words.Native.Test
    test/Words.Native.Test/HashtableTest.cpp
    test/Words.Native.Test/LetterBoxStrSearchTest.cpp
    test/Words.Native.Test/LetterBoxStrTest.cpp
    test/Words.Native.Test/LetterBoxStrWordsTest.cpp
    test/Words.Native.Test/StopwatchTest.cpp
    test/Words.Native.Test/StrTest.cpp
    test/Words.Native.Test/StrTrieTest.cpp
)

target_link_libraries(Words.Native.Test
    Words.Native.Core
    GTest::GTest
    GTest::Main
)

enable_testing()

gtest_discover_tests(Words.Native.Test)
