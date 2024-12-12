@echo off
set ANT_HOME=C:\\Ephesoft\\TransactApp\\dependencies/license-util/apache-ant-1.6.5
set EPHESOFT_HOME=C:\\Ephesoft\\TransactApp\\Application
set path=%path%;%ANT_HOME%\bin;
ant -f C:\\Ephesoft\\TransactApp\\Dependencies/license-util/ephesoft-license-installer/run.xml
