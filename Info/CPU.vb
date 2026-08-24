Imports System.Threading
Imports System.Windows.Forms

Public Class CPU

    Private Declare Auto Function GetSystemTimes Lib "kernel32.dll" (ByRef IdleTime As Int64, ByRef KernelTime As Int64, ByRef UserTime As Int64) As Boolean

    Private m_SpinEnabled As Boolean = False
    Private m_DesiredCPUUtilisation As Integer = 25
    Private m_DesiredPerCoreUtilisation As Integer = 6
    Private m_CurrentUtilisation As Integer = 0
    Private m_CoreCount As Int16 = System.Environment.ProcessorCount
    Private WithEvents m_Timer As New Timers.Timer(1000)
    Private m_UpdateInterval As Short = 250
    Private m_CalculationMutex As New Mutex

    Public ReadOnly Property CurrentUtilisation() As Double
        Get
            GetCPUUtilisation()
            Return m_CurrentUtilisation
        End Get
    End Property

    Public Property SpinEnabled() As Boolean
        Get
            Return m_SpinEnabled
        End Get
        Set(ByVal value As Boolean)
            m_SpinEnabled = value
        End Set
    End Property

    Public Property DesiredCPUUtilisation() As Integer
        Get
            Return m_DesiredCPUUtilisation
        End Get
        Set(ByVal value As Integer)
            m_DesiredCPUUtilisation = value
        End Set
    End Property

    Public ReadOnly Property CoreCount() As Int16
        Get
            Return m_CoreCount
        End Get
    End Property

    Public Sub New()
        m_Timer.AutoReset = True
        m_Timer.Enabled = False

        GetCPUUtilisation()
    End Sub

    Public Sub StartCPUSpin()
        Dim ThreadSpinner(m_CoreCount) As Threading.Thread
        Dim CPUUtilisationCalculator As New Thread(AddressOf GetCPUUtilisation)

        CPUUtilisationCalculator.Start()

        m_DesiredPerCoreUtilisation = m_DesiredCPUUtilisation / m_CoreCount
        For SpinCount As Int16 = 1 To m_CoreCount
            ThreadSpinner(SpinCount) = New Threading.Thread(AddressOf DoSpin)

            ThreadSpinner(SpinCount).Start()
        Next

    End Sub

    Private Sub DoSpin()
        Dim WastedResult As Double = 0.0

        Do
            Do
                'WastedResult = Math.Sqrt(New Random(0).Next)
                Application.DoEvents()
            Loop Until (m_CurrentUtilisation >= m_DesiredCPUUtilisation) Or (Not m_SpinEnabled)
            Application.DoEvents()
            Thread.Sleep(100)
        Loop Until Not m_SpinEnabled
    End Sub

    Private Sub m_Timer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles m_Timer.Elapsed

        'm_CurrentUtilisation = GetCPUUtilisation()
        'Debug.Print(m_CurrentUtilisation.ToString)

    End Sub

    Private Sub GetCPUUtilisation()
        'These are to hold the starting times values.
        Dim StartIdle As Int64
        Dim StartKernel As Int64
        Dim StartUser As Int64

        'These variables are to hold the ending times values.
        Dim EndIdle As Int64
        Dim EndKernel As Int64
        Dim EndUser As Int64

        'These will hold the values that are calculated from the ending and starting times values.
        Dim CalculatedIdle As Integer
        Dim CalculatedKernel As Integer
        Dim CalculatedUser As Integer

        'This variable will contain the values of m_CalculatedKernel + m_CalculatedUser.
        Dim SystemTime As Integer

        Do
            m_CalculationMutex.WaitOne()

            GetSystemTimes(StartIdle, StartKernel, StartUser)

            StartIdle = Val(StartIdle)
            StartKernel = Val(StartKernel)
            StartUser = Val(StartUser)

            Thread.Sleep(m_UpdateInterval)

            'Retrieve the Times values after the Delay.
            GetSystemTimes(EndIdle, EndKernel, EndUser)

            EndIdle = Val(EndIdle)
            EndKernel = Val(EndKernel)
            EndUser = Val(EndUser)

            'Get the values calculated between the starting and ending Times values.
            CalculatedIdle = (EndIdle - StartIdle)
            CalculatedKernel = (EndKernel - StartKernel)
            CalculatedUser = (EndUser - StartUser)

            'Calculate the total system time. Which is Kernel and User time together.
            SystemTime = (CalculatedKernel + CalculatedUser)
            Application.DoEvents()

            'Now calculate the values as a percentage based number.
            If SystemTime > 0 And CalculatedIdle > 0 Then
                m_CurrentUtilisation = (SystemTime - CalculatedIdle) * (100) \ (SystemTime)
            Else
                m_CurrentUtilisation = 0
            End If

            m_CalculationMutex.ReleaseMutex()

            Thread.Sleep(m_UpdateInterval)
        Loop Until Not m_SpinEnabled
    End Sub

End Class
