Imports System.IO
Imports System.Resources
Imports System.Runtime.InteropServices
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ApplicationServices
Public Class Restore

    Dim Study As Project
    Public Sub New(ByRef _Study As Project)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Study = _Study

    End Sub
    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim DIR As String = $"C:\Ad Loader\{Study.SID}\Ads\"
        For Each File As String In My.Computer.FileSystem.GetFiles(DIR, FileIO.SearchOption.SearchTopLevelOnly, $"{Study.SID}_Version.txt.*")
            If File <> $"{DIR}{Study.SID}_Version.txt" Then
                Dim FileInfo As String = Replace(Replace(Replace(Replace(File, "_", " "), ".txt.", ": "), DIR, ""), Study.SID, "") & " - " & My.Computer.FileSystem.GetFileInfo(File).LastAccessTime
                RestoreAllTree.Nodes.Add(File, FileInfo)
            End If
        Next

        For Each Directory As String In My.Computer.FileSystem.GetDirectories(DIR, FileIO.SearchOption.SearchTopLevelOnly)
            Dim TreeNode As New TreeNode
            TreeNode.Name = Replace(Directory, DIR, "")
            TreeNode.Text = Replace(Directory, DIR, "")
            RestoreSelectedTree.Nodes.Add(TreeNode)

            'Remove Checkboxes from all Root Nodes

            For Each SubDirectory As String In My.Computer.FileSystem.GetDirectories(Directory & "\", FileIO.SearchOption.SearchTopLevelOnly)
                Dim SubTreeNode As New TreeNode
                SubTreeNode.Name = Replace(SubDirectory, Directory & "\", "")
                SubTreeNode.Text = Replace(SubDirectory, Directory & "\", "")
                TreeNode.Nodes.Add(SubTreeNode)
                For Each File As String In My.Computer.FileSystem.GetFiles(SubDirectory & "\", FileIO.SearchOption.SearchTopLevelOnly, $"{Study.SID}_Staging.txt.*")
                    If File <> $"{SubDirectory}\{Study.SID}_Staging.txt" Then
                        Dim FileInfo As String = Mid(File, File.LastIndexOf("\") + 2)
                        FileInfo = Replace(FileInfo, ".txt.", ": ") & " - " & My.Computer.FileSystem.GetFileInfo(File).LastAccessTime
                        Dim FileTreeNode As New TreeNode
                        FileTreeNode.Name = File
                        FileTreeNode.Text = FileInfo
                        SubTreeNode.Nodes.Add(FileTreeNode)
                    End If
                Next
            Next
        Next
        For Each node As TreeNode In RestoreSelectedTree.Nodes
            TreeNode_SetStateImageIndex(node, 0)
            For Each ChildNode As TreeNode In node.Nodes
                TreeNode_SetStateImageIndex(ChildNode, 0)
            Next
            TreeNode_SetStateImageIndex(node, 0)
        Next

        RestoreSelectedTree.ExpandAll()

    End Sub

    Public Const TVIF_STATE As Integer = &H8
    Public Const TVIS_STATEIMAGEMASK As Integer = &HF000
    Public Const TV_FIRST As Integer = &H1100
    Public Const TVM_SETITEM As Integer = TV_FIRST + 63

    <StructLayout(LayoutKind.Sequential)> Public Structure TVITEM
        Public mask As Integer
        Public hItem As IntPtr
        Public state As Integer
        Public stateMask As Integer
        <MarshalAs(UnmanagedType.LPTStr)> Public lpszText As String
        Public cchTextMax As Integer
        Public iImage As Integer
        Public iSelectedImage As Integer
        Public cChildren As Integer
        Public lParam As IntPtr
    End Structure

    Public Overloads Declare Auto Function SendMessage Lib "User32.dll" (ByVal hwnd As IntPtr,
    ByVal msg As Integer, ByVal wParam As IntPtr, ByRef lParam As TVITEM) As Integer

    Public Sub TreeNode_SetStateImageIndex(ByVal node As TreeNode, ByVal index As Integer)
        Dim tvi As TVITEM
        tvi.hItem = node.Handle
        tvi.mask = TVIF_STATE
        tvi.stateMask = TVIS_STATEIMAGEMASK
        tvi.state = index << 12
        SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, tvi)
    End Sub



    Private _isHandlerPaused As Boolean = False
    Private Sub RestoreSelectedTree_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles RestoreSelectedTree.AfterCheck

        If e.Node.Checked = True Then
            If _isHandlerPaused = True Then Exit Sub
            _isHandlerPaused = True
            Dim SelectedNode As TreeNode = e.Node
            For Each Node As TreeNode In SelectedNode.Parent.Nodes
                If Node.Checked = True Then
                    Node.Checked = False
                End If
            Next
            SelectedNode.Checked = True
            _isHandlerPaused = False
        End If

        If _isHandlerPaused = False Then
            Dim isSelected As Boolean = False
            For Each Node As TreeNode In RestoreSelectedTree.Nodes
                For Each SubNode As TreeNode In Node.Nodes
                    For Each ChildNode As TreeNode In SubNode.Nodes
                        If ChildNode.Checked = True Then
                            isSelected = True
                            Exit For
                        End If
                    Next
                Next
            Next

            If isSelected Then
                btnRestoreSelected.Enabled = True
            Else
                btnRestoreSelected.Enabled = False
            End If
        End If

    End Sub

    Private Sub RestoreAllTree_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles RestoreAllTree.AfterCheck

        If e.Node.Checked = True Then
            If _isHandlerPaused = True Then Exit Sub
            _isHandlerPaused = True
            Dim SelectedNode As TreeNode = e.Node
            For Each Node As TreeNode In RestoreAllTree.Nodes
                If Node.Checked = True Then
                    Node.Checked = False
                End If
            Next
            SelectedNode.Checked = True
            _isHandlerPaused = False
        End If

        If _isHandlerPaused = False Then
            Dim isSelected As Boolean = False
            For Each Node As TreeNode In RestoreAllTree.Nodes
                If Node.Checked = True Then
                    isSelected = True
                    Exit For
                End If
            Next

            If isSelected Then
                btnRestoreAll.Enabled = True
            Else
                btnRestoreAll.Enabled = False
            End If
        End If

    End Sub

    Private Sub btnRestoreAll_Click(sender As Object, e As EventArgs) Handles btnRestoreAll.Click
        Dim Backedup As Boolean = False
        For Each Node As TreeNode In RestoreAllTree.Nodes
            If Node.Checked = True Then
                Dim Version As String = Mid(Node.Name, Node.Name.LastIndexOf(".txt") + 5)
                For Each file As String In My.Computer.FileSystem.GetFiles($"C:\Ad Loader\{Study.SID}\Ads\", FileIO.SearchOption.SearchAllSubDirectories, "*" & Version)
                    My.Computer.FileSystem.CopyFile(file, Replace(file, Version, ""), True)
                    Backedup = True
                Next
            End If
        Next

        If Backedup Then
            Dim RestartInfo As New Restart(Study.Login.txtUserName.Text, Study.Login.txtSID.Text, Study.Login.boxServer.Text)
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(Restart))
            Dim RestartResx As StreamWriter = New StreamWriter("C:\Ad Loader\Restart.resx")
            mySerializer.Serialize(RestartResx, RestartInfo)
            RestartResx.Close()
            Application.Restart()
        End If

    End Sub
    Private Sub btnRestoreSelected_Click(sender As Object, e As EventArgs) Handles btnRestoreSelected.Click
        Dim Backedup As Boolean = False
        For Each Node As TreeNode In RestoreSelectedTree.Nodes
            For Each SubNode As TreeNode In Node.Nodes
                For Each ChildNode As TreeNode In SubNode.Nodes
                    If ChildNode.Checked = True Then
                        Dim Version As String = Mid(ChildNode.Name, ChildNode.Name.LastIndexOf(".txt") + 5)
                        My.Computer.FileSystem.CopyFile(ChildNode.Name, Replace(ChildNode.Name, Version, ""), True)
                        Backedup = True
                    End If
                Next
            Next
        Next

        If Backedup Then
            Dim RestartInfo As New Restart(Study.Login.txtUserName.Text, Study.Login.txtSID.Text, Study.Login.boxServer.Text)
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(Restart))
            Dim RestartResx As StreamWriter = New StreamWriter("C:\Ad Loader\Restart.resx")
            mySerializer.Serialize(RestartResx, RestartInfo)
            RestartResx.Close()
            Application.Restart()
        End If

    End Sub
End Class


<Serializable()> Public Class Restart

    Public Username As String
    Public SID As String
    Public FTPServer As String

    Public Sub New()
        ' Optional: Initialize properties with default values
        Username = String.Empty
        SID = String.Empty
        FTPServer = String.Empty
    End Sub

    Sub New(ByVal _User As String, _SID As String, ByVal Server As String)
        Username = _User
        SID = _SID
        FTPServer = Server
    End Sub

End Class

