#!/usr/bin/env bash

PARENT_PATH=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
URL="https://github.com/twilio/twilio-video-ios/releases/download/2.10.0/TwilioVideo.framework.zip"
ZIP_NAME="TwilioVideo.framework.zip"
LIB_DIR="build"

cd "$PARENT_PATH"
curl -L $URL > $ZIP_NAME
tar -xf $ZIP_NAME
mkdir -p "Native References"
mv $LIB_DIR/iOS/TwilioVideo.framework "Native References"/TwilioVideo.framework
rm -rf $LIB_DIR
rm $ZIP_NAME 
