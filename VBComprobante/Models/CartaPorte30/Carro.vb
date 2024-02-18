Public Class Carro

	Private _tipoCarro As String = ""
	Private _matriculaCarro As String = ""
	Private _guiaCarro As String = ""
	Private _toneladasNetasCarro As Decimal
	Private _contenedor As List(Of CarroContenedor) = New List(Of CarroContenedor)

	Public Property TipoCarro As String
		Get
			Return _tipoCarro
		End Get
		Set(value As String)
			_tipoCarro = value
		End Set
	End Property


	Public Property MatriculaCarro As String
		Get
			Return _matriculaCarro
		End Get
		Set(value As String)
			_matriculaCarro = value
		End Set
	End Property

	Public Property GuiaCarro As String
		Get
			Return _guiaCarro
		End Get
		Set(value As String)
			_guiaCarro = value
		End Set
	End Property

	Public Property ToneladasNetasCarro As Decimal
		Get
			Return _toneladasNetasCarro
		End Get
		Set(value As Decimal)
			_toneladasNetasCarro = value
		End Set
	End Property

	Public Property Contenedor As List(Of CarroContenedor)
		Get
			Return _contenedor
		End Get
		Set(value As List(Of CarroContenedor))
			_contenedor = value
		End Set
	End Property

End Class
