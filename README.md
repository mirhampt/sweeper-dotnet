# Sweeper

## Getting Started

I recommend using the VS Code dev container configured for the repository.
This will use Docker to setup and remote into a dotnet dev environment. The
C# VS Code plugin is configured to run in the dev container.

```
cd SweeperWASM
dotnet watch run
```

Open http://localhost:5000.

## What is this?

Just a weekend exploration of Blazor WASM. A very simple Mine Sweeper clone.

## Improvements

I don't know C# or dotnet well--I'm sure I made plenty of
more-awkward-than-necessary decisions (those for loops in SweeperGame). Given
the time, I might come back and refactor when I'm curious to learn more.

Remove bootstrap. It's included with the default project skeleton for Blazor
and is certainly not needed for this project.

Also, I crammed everything into one Blazor component. I'd like to come back
and rework it into a better hierarchy as I would with React.

Finally, given the time, I'd like to learn about and implement testing
strategies for Blazor.

## What's next?

Besides the refactoring above, I think I might reimplement this with Rust
compiled to WASM for the core game logic and a React interface one weekend
just to satisfy my own curiosity and excitement about WASM.

## Final Thoughts

My biggest take-away: VS Code dev containers are fantastic.

Does this project make sense for Blazor WASM? Not really. The resulting WASM
download is quite large for such a small project. Given the right project and
better knowledge of C# than me, Blazor could be a great choice. I had fun
exploring it.
