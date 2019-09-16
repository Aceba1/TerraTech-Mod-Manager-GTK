#!/bin/sh
if [[ "$OSTYPE" == "darwin"* ]]; then
        /Library/Frameworks/Mono.framework/Versions/Current/Commands/mono TerraTechModManager-GTK.exe
else
        mono TerraTechModManager-GTK.exe
fi