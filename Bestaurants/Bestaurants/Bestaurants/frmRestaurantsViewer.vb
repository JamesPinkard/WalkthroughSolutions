Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI

Public Class frmRestaurantsViewer

    Private _application As IApplication
    Public Property ArcMapApplication() As IApplication
        Get
            Return _application
        End Get
        Set(ByVal value As IApplication)
            _application = value
        End Set
    End Property


    Private Sub cmdShow_Click(sender As Object, e As EventArgs) Handles cmdShow.Click


        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        pSelectedLayer.Visible = True

        Dim pMxdoc As IMxDocument = _application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActiveView.Refresh()

    End Sub

    Private Sub cmdHide_Click(sender As Object, e As EventArgs) Handles cmdHide.Click

        Dim pSelectedLayer As ILayer = getLayerByName(cmbLayers.SelectedItem.ToString)
        pSelectedLayer.Visible = False

        Dim pMxdoc As IMxDocument = _application.Document
        pMxdoc.UpdateContents()
        pMxdoc.ActiveView.Refresh()


    End Sub

    ''' <summary>
    ''' Get the layer by name 
    ''' </summary>
    ''' <param name="sLayerName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getLayerByName(sLayerName As String) As ILayer
        Try

            Dim pMxDoc As IMxDocument = _application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            For i As Integer = 0 To pMap.LayerCount - 1
                Dim pLayer As ILayer = pMap.Layer(i)

                If pLayer.Name = sLayerName Then
                    Return pLayer
                End If

            Next

            'if you are here then you didn't find the layer... return nothing
            Return Nothing


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function


End Class