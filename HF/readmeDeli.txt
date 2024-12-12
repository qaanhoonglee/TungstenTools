IMPORTANT NOTES
===============
1. If the Transact server fails to start or does not perform as expected following deployment of this hotfix, the changes can be reverted by following the steps in the 'Steps to revert the hotfix' section below but it is recommended you speak with the Ephesoft support team first in this event.
2. Please read the deployment and roll-back steps below fully before proceeding. If anything is unclear, consider contacting our support team for assistance.
3. As with any Transact system change, it is considered best practice, and is strongly recommended, that this hotfix be deployed to your Test environment and tested thoroughly before live deployment to your Production environment.

Note: It is mandatory to deploy all the earlier Generic HFs before this current one in ascending order. In case of concerns, contact Ephesoft support team for assistance.

Hotfix deployment steps
========================

[Step 1 of 4] Extract the hotfix Zip archive contents to the 'Version' folder within the Ephesoft Transact folder. NB: This step can be skipped if this action has already been completed.
1.1 Stop the Transact server if running.
1.2 Navigate to Ephesoft Transact location.
1.3 If it does not yet exist, create a new folder named 'Version' directly beneath the Ephesoft root, for example, the path may look like this on a single server Windows deployment: "c:\Ephesoft\Version\" .
1.4 Extract the contents of the Zip archive file into the Version folder. The operation may create a path that looks like this: "c:\Ephesoft\Version\{version}\" .

[Step 2 of 4] Backup the current components.
{HOT_FIX_JAR_BACKUP}
{FOLDER_FILE_META_INF_PROP_REPLACE_BACKUP}

[Step 3 of 4] Deploy changes
{HOT_FIX_JAR_DEPLOY}
{FOLDER_FILE_META_INF_PROP_REPLACE_DEPLOY}
{DB_SCRIPT_DEPLOY}
	
[Step 4 of 4] Start Transact and perform test cycle
4.1 Start the Ephesoft server
   Note: In a clustered environment it is adviced that nodes shall be started only after ALL nodes have been upgraded.
4.2 Perform verifications as suggested in the important notes above.

Steps to revert the hotfix
===========================
If you encounter problems after deploying this hotfix and need to reverse the changes, you can follow the steps below to revert the changes. If you do encounter problems with deployment, it is recommended that you speak with the Ephesoft support team in the first instance.
[Step 1 of 3] Stop Transact and clean-up
1.1 Stop the Ephesoft server.
{HOT_FIX_JAR_REVERT}
{FOLDER_FILE_META_INF_PROP_REPLACE_REVERT}
{DB_SCRIPT_REVERT}
	
[Step 2 of 3] Revert changes
{HOT_FIX_JAR_REVERT_CHANGE}
{FOLDER_FILE_META_INF_PROP_REPLACE_REVERT_CHANGE}
{DB_SCRIPT_REVERT_CHANGE}

[Step 3 of 3] Remove the hotfix signature. NB: Failure to follow this step may cause problems with future hotfixes.
3.1 Delete the '{version}' folder from the Version folder in the Transact location, the path may look like this on a single server Windows deployment: c:\Ephesoft\Version\{version}\ .