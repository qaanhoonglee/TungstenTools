IMPORTANT NOTES
===============
1. If the Transact server fails to start or does not perform as expected following deployment of this hotfix, the changes can be reverted by following the steps in the 'Steps to revert the hotfix' section below but it is recommended you speak with the Ephesoft support team first in this event.
2. Please read the deployment and roll-back steps below fully before proceeding. If anything is unclear, consider contacting our support team for assistance.
3. As with any Transact system change, it is considered best practice, and is strongly recommended, that this hotfix be deployed to your Test environment and tested thoroughly before live deployment to your Production environment.
4. For Webscanner deployment please refer to 'Steps to deploy WebScanner patch'.

Note: It is mandatory to deploy all the earlier Generic HFs before this current one in ascending order. In case of concerns, contact Ephesoft support team for assistance.This is {version}	hotfix, so please check all the pervious hotfixes ({version-from} to {version}) is installed at the location "C:\Ephesoft\Version".

This hotfix contains all the PDT tool supported changes.

A. For deploying this Hotfix by Automatic approach using (PDT Tool) follow the below steps.
-----------------------------------------------------------------------------------------

Hotfix deployment steps(PDT Tool) 
=================================

1. Stop the Transact server if running.
2. Copy the "deliverables\{hotfix-name}.zip" file inside the deliverables folder of PDT tool. The path may look like "PDT-TOOL\deliverables". Make sure only Hotfix-2022.1.00.011-Windows.zip file is there and remove all the other files/folders, otherwise PDT tool will install all the hotfixes places inside the deliverables folder.
3. Run cmd as Administrator and navigate to the PDT tool location.
4. Run command "generic_installer.bat" (Windows) or "generic_installer.sh" (Linux) to install the hotfix.
5. Start Transact and perform test cycle
	5.1. Start the Ephesoft server
         Note: In a clustered environment it is adviced that nodes shall be started only after ALL nodes have been upgraded.
    5.2. Perform verifications as suggested in the important notes above.
	
Steps to revert the hotfix(PDT Tool)
====================================
1. Stop Service Ephesoft
2. Extract {hotfix-name}.zip and copy PDT-TOOL into the same entry directory with ephesoft setting directory.
3. Run cmd as Administrator and navigate to the PDT tool location.
4. Run command "generic_uninstaller.bat"(Windows) or "generic_uninstaller.bat" (Linux) to uninstall the hotfix.
5. Start Service Ephesoft

B. For deploying this Hotfix by Manual approach.
------------------------------------------------
To install this hotfix manually unzip the {hotfix-name}.zip in a temporary location and open the readme.txt to perform further steps.


Steps to deploy Ephesoft
---------------------------------

[Instruction] Deploy Ephesoft hotfix {hotfix-name}:

1.1 Stop Ephesoft service.
{PDT-Deploy}

