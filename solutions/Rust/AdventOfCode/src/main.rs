use std::env;

fn main() {

    let args: Vec<String> = env::args().collect();

    println!("Program Name: {}", args[1]);
    println!("Program Name: {}", args[2]);

    println!("Hello, world!");
}
