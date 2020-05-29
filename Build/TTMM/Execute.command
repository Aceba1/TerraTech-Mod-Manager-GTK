#!/bin/sh
if [[ "$OSTYPE" == "darwin"* ]]; then
        /Library/Frameworks/Mono.framework/Versions/Current/Commands/mono $(dirname "${BASH_SOURCE[0]}")/TerraTechModManager-GTK.exe
else
        mono TerraTechModManager-GTK.exe
fi