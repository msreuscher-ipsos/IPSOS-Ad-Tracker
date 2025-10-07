Imports System.Resources

Public Class ListSelector

    Public ParentList As ListManager
    Private Sub ExcludeTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveToolStripMenuItem.Click
        ParentList.ParentProject.ExcludeLists.Add(ParentList.Name, ParentList)
        ParentList.ParentProject.Lists.Remove(ParentList.Name)
        ParentList.ParentProject.FlowLayout.Controls.Remove(ParentList.Tool)
        ParentList.ParentProject.ListPanel.Controls.Remove(Me)
    End Sub

    Private Sub btnTool_Click(sender As Object, e As EventArgs) Handles btnTool.Click
        ParentList.Visible = True
        ParentList.BringToFront()
    End Sub

    Private Sub lblRemove_MouseEnter(sender As Object, e As EventArgs) Handles lblRemove.MouseEnter
        lblRemove.ForeColor = SystemColors.MenuHighlight
    End Sub

    Private Sub lblRemove_MouseLeave(sender As Object, e As EventArgs) Handles lblRemove.MouseLeave
        lblRemove.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub lblRemove_Click(sender As Object, e As EventArgs) Handles lblRemove.Click
        ContextMenuStrip.Show(lblRemove, New Point(0, lblRemove.Height))
    End Sub
End Class
