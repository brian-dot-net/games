use letter_boxed_solver::{
    core::{LetterBox, St},
    trie::StTrie,
};
use std::{env::args, fs::File, time::Instant};

fn main() {
    let start = Instant::now();
    let args: Vec<String> = args().skip(1).collect();
    if args.len() != 2 {
        println!("Please specify a Letter Boxed puzzle and a word list file.");
        return;
    }

    let b = LetterBox::new(args[0].parse::<St>().unwrap());

    log(start, "Loading trie...");
    let mut stream = File::open(&args[1]).unwrap();
    let trie = StTrie::load(&mut stream);
    log(start, format!("Loaded {} words.", trie.len()).as_str());
}

fn log(start: Instant, message: &str) {
    println!("[{:07.3}] {}", start.elapsed().as_secs_f64(), message);
}
