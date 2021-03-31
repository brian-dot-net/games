use letter_boxed_solver::trie::StTrie;
use std::{env::args, fs::File, time::Instant};

fn main() {
    let start = Instant::now();
    let args = args();
    if args.len() != 3 {
        println!("Please specify a Letter Boxed puzzle and a word list file.");
        return;
    }

    log(start, "Loading trie...");
    let path = args.skip(2).next().unwrap();
    let mut stream = File::open(path).unwrap();
    let trie = StTrie::load(&mut stream);
    log(start, format!("Loaded {} words.", trie.len()).as_str());
}

fn log(start: Instant, message: &str) {
    println!("[{:07.3}] {}", start.elapsed().as_secs_f64(), message);
}
