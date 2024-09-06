Imports DXSample.Proxy
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports DXSample.PersistentClasses

Namespace DXSample

    Public Module XpoHelper

        Public Function GetNewSesion() As Session
            Return New Session(DataLayer)
        End Function

        Public Function GetNewUnitOfWork() As UnitOfWork
            Return New UnitOfWork(DataLayer)
        End Function

        Private ReadOnly lockObject As Object = New Object()

         ''' Cannot convert FieldDeclarationSyntax, System.NotSupportedException: VolatileKeyword is not supported!
'''    at ICSharpCode.CodeConverter.VB.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.<>c__DisplayClass30_0.<ConvertModifiersCore>b__3(SyntaxToken x)
'''    at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
'''    at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
'''    at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
'''    at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.ConvertModifiersCore(IReadOnlyCollection`1 modifiers, TokenContext context, Boolean isConstructor, Boolean isNestedType)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''         static volatile DevExpress.Xpo.IDataLayer fDataLayer;
''' 
'''  Private ReadOnly Property DataLayer As IDataLayer
            Get
                If XpoHelper.fDataLayer Is Nothing Then
                    SyncLock lockObject
                        If XpoHelper.fDataLayer Is Nothing Then XpoHelper.fDataLayer = GetDataLayer()
                    End SyncLock
                End If

                Return XpoHelper.fDataLayer
            End Get
        End Property

        Private Function GetDataLayer() As IDataLayer
            XpoDefault.Session = Nothing
            Dim dict As XPDictionary = New ReflectionDictionary()
            dict.GetDataStoreSchema(GetType(Person).Assembly)
            Return New ThreadSafeDataLayer(dict, New DataCacheNode(New CachingDataStore("http://localhost:1556/CachingService.asmx")))
        End Function
    End Module
End Namespace
