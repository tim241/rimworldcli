#!/usr/bin/env bash
export version=11
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

dotnet publish -r linux-x64 -c Release --self-contained

if [ -d Bin/AppImage ]
then
    rm -rf Bin/AppImage
fi

mkdir -p Bin/AppImage
mkdir -p Bin/AppImage/src/usr/bin/

cp Bin/netcoreapp2.1/linux-x64/publish/* Bin/AppImage/src/usr/bin/

cp Scripts/package/AppRun Bin/AppImage/src/AppRun
cp Scripts/package/rtcmd.desktop Bin/AppImage/src/rtcmd.desktop 

chmod 775 Bin/AppImage/src/AppRun

touch Bin/AppImage/src/rtcmd.png

if [ ! -f Bin/appimagetool ]
then
    curl -L https://github.com/AppImage/AppImageKit/releases/download/$version/appimagetool-x86_64.AppImage \
      -o Bin/appimagetool
fi

chmod +x Bin/appimagetool

# Create appimage without AppStream metadata check
./Bin/appimagetool -n Bin/AppImage/src Bin/AppImage/rtcmd
