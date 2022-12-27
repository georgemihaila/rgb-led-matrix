#!/bin/bash
echo 'Stopping runner...'
systemctl stop matrixrunner
echo 'Stopping server...'
systemctl stop matrixserver
cd ~/rgb-led-matrix
echo 'Fetching changes...'
git fetch
git pull
cd ~/rgb-led-matrix/LEDMatrix
echo 'Restoring...'
dotnet restore
echo 'Building...'
dotnet build
echo 'Copying dependencies...'
cp /home/pi/rpi-rgb-led-matrix/bindings/c#/examples/librgbmatrix.so librgbmatrix.so
echo 'Starting runner...'
systemctl start matrixrunner
echo 'Starting server...'
systemctl start matrixserver