# UnSparseISO

Sometimes when you downloaded a disk image from internet and if you are with Windows 7, 8, or 8.1, you could get error message saying: "Couldn't Mount File: Sorry there was a problem mounting the file", while mounting the disk image.

One of the possible solutions is to copy the file and after this everything works. But what will happen if the file is, let's say around 60GB or 80GB and you don't want to wait for another 20 or 30 minutes to copy the file, or even worst you don't have enough disk space to do that.

One of the problems causing this error is that the file is flagged as SPARSE and this flag needs to be removed in addition the disk image to mount.

# Requirements
- Windows 7, 8 or 8.1 Operation System
- .NET version 4.0

# How does this thingy works?
1. You launch the application from the EXE folder.
2. Select the file by clicking the Browse button or typing the filename in the textbox.
3. Click the button "Remove Sparse Flag".
4. Wait till the process completes.
5. Try to mount the disk image.

# Note: 
If you type in the filename in the textbox, the app will search for the file in the current directory.

# What this thingy does?
1. Try to get the attributes of the selected file.
2. Remove the Read-Only flag, if it is set.
3. Set the Sparse flag to 0 (zero), if it is set to 1 (one).
