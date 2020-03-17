#!/usr/bin/env bash

msbuild -t:Clean,Build -p:Configuration=Release Twilio.Video.iOS.csproj
nuget pack twilio-video.nuspec 