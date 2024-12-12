#!/bin/sh
#set echo off
filename='/etc/Ephesoft/ephesoft.conf'
while read line; do
# reading each line
if [[ $line =~ .*ephesoft_application.* ]]; then
arrIN=(${line//=/ })
fi
done < $filename
VAR1=${arrIN[1]}
VAR2=$VAR1/Dependencies/jdk;
echo "JAVA_HOME:$VAR2";
echo "EPHESOFT_HOME:$VAR1";

$VAR2/bin/java -jar ephesoft-generic-installer-1.0-SNAPSHOT.jar $VAR1 install
