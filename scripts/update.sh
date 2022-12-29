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
echo 'Cleaning...'
#dotnet clean
echo 'Restoring...'
dotnet restore
echo 'Building...'
dotnet build --configuration=Release
echo 'Copying dependencies...'
#cp /home/pi/rpi-rgb-led-matrix/bindings/c#/examples/librgbmatrix.so librgbmatrix.so
#cp /home/pi/rpi-rgb-led-matrix/bindings/c#/examples/RGBLedMatrix.dll RGBLedMatrix.dll
#cp -R /home/pi/rpi-rgb-led-matrix/lib/* .
cp -R /home/pi/rpi-rgb-led-matrix/lib/* /root/rgb-led-matrix/LEDMatrix/LEDMatrix.Runner/bin/Release/net6.0
cp /root/rgb-led-matrix/LEDMatrix/LEDMatrix.Runner/bin/Release/net6.0/librgbmatrix.so.1  /root/rgb-led-matrix/LEDMatrix/LEDMatrix.Runner/bin/Release/net6.0/librgbmatrix.so
echo 'Starting runner...'
systemctl start matrixrunner
echo 'Starting server...'
systemctl start matrixserver
echo 'Getting status...'
sleep 1
systemctl status matrixrunner
systemctl status matrixserver