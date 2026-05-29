<%
Class HashTable

	'first two variables are un-dimensioned arrays. These two arrays
	'hold all of the contents of the hash table. By bending the rules
	'as much as possible, these two arrays by themselves can fake a
	'hash table. The class interface only provides an easier way to work
	'with the 2 array variables with less confusion. The third variable is
	'a global counter indicating the total number of elements in the
	'first 2 global array variables.

	Private HashTable_Names()
	Private HashTable_Values()
	Private HashTable_Count

	Private Sub Class_Initialize()
		'class initialize event...
		'set the global array incrementer variable
		'at -1 to start
		HashTable_Count = -1
	End Sub

	Private Sub Class_Terminate()
		'class terminate event...
		'call the class's removeall( ) method
		'to redimension the two hash table
		'arrays and reset the global counter,
		'freeing up memory.
		RemoveAll
	End Sub

	Public Function UpdateHashValue(ByVal sName, ByVal sNewValue)
		'updates the value of a key, returns the old value
		'of the key (the value that was just replaced)
		Dim i, sOut

		sOut = ""

		'loop through the array of names, looking for an
		'exact (case sensitive) match
		For i = 0 to UBound(HashTable_Names)
			If sName = HashTable_Names(i) Then

				'if the key is found, return the
				'old value and replace the old
				'value with the new value specified
				'in the hash table's values array.
				sOut = HashTable_Values(i)
				HashTable_Values(i) = sNewValue
				Exit For
			End If
		Next
		UpdateHashValue = sOut
	End Function

	Public Function Remove(ByVal sName)
		'removes a key/value pair by key
		Dim i, j, vOut

		'loop through the hash table's names array looking for
		'an exact match.
		For i = 0 to UBound(HashTable_Names)
			If sName = HashTable_Names(i) Then
				'if found, return the key/value pair to be removed
				'as an array with 2 elements...
				vOut = Array(HashTable_Names(i), HashTable_Values(i))
				HashTable_Names(i) = ""
				HashTable_Values(i) = ""
				'loop through the name/value arrays and move all the
				'hash table entries up one element, starting at the
				'element we just removed.
				For j = i to UBound(HashTable_Names)
					if j + 1 > UBound(HashTable_Names) then Exit For

					HashTable_Names(j) = HashTable_Names(j + 1)
					HashTable_Values(j) = HashTable_Values(j + 1)
				Next
				'drop 1 from the global count of array elements cause
				'were redimming the array - 1 element
				HashTable_Count = HashTable_Count - 1
				'use the Preserve keyword so that the values
				'already entered stay in the arrays
				Redim Preserve HashTable_Names(HashTable_Count), _
				               HashTable_Values(HashTable_Count)
				Remove = vOut
				Exit Function
			End If
		Next
		Remove = ""
	End Function

	Public Sub RemoveAll()
		'clean out the hash table. Redim the array to -1,
		'removing all elements. reset the internal element
		'counter so that it matches...
		Redim HashTable_Names(-1), HashTable_Values(-1)
		HashTable_Count = -1
	End Sub

	Public Sub Add(ByVal sName, ByVal sValue)
		'add a key/value pair to the dictionary. Key is case
		'sensitive.
		Dim i

		'if this is the first entry into the hash table
		If HashTable_Count < 0 then
			'set the hash table element counter to a number
			'that represents the first element in an array
			'(that's always 0)
			HashTable_Count = 0
			'redimension the array's that fake the hash table.
			Redim HashTable_Names(0), HashTable_Values(0)
			'set the value of the first elements equal to
			'what was entered in the arguments...
			HashTable_Names(0) = sName
			HashTable_Values(0) = sValue
		Else
			'if other elements exist in the hash table,
			'increment the hash table element variable
			HashTable_Count = HashTable_Count + 1
			'redimension the internal arrays, this time
			'using the preserve keyword so that other
			'entries in the hash table are still there.
			Redim Preserve HashTable_Names(HashTable_Count), _
			               HashTable_Values(HashTable_Count)
			'loop through the hash table elements, trying to
			'match the name. if it's found, raise an error cause
			'no duplicate key's are allowed.
			For i = 0 to UBound(HashTable_Names)
				If sName = HashTable_Names(i) Then
					Err.Raise 35675, _
						"No Duplicate Key Names " & _
						"Allowed In Hash Table"
					Exit Sub
				End If
			Next
			'set the new key/value pair in the hash table.
			HashTable_Names(HashTable_Count) = sName
			HashTable_Values(HashTable_Count) = sValue
		End If
	End Sub

	Public Function Count()
		'return the global counter variable + 1
		Count = HashTable_Count + 1
	End Function

	Public Function Exists(ByVal sName)
		'determine whether or not a key exists already in the
		'hash table.
		Dim i

		'loop through the hash table
		For i = 0 to UBound(HashTable_Names)
			'if the name is found, return true
			If sName = HashTable_Names(i) Then
				Exists = True
				Exit Function
			End If
		Next
		'otherwise return false.
		Exists = False
	End Function

	Public Function GetValue(ByVal sName)
		'returns the value of a specified key
		Dim i, sOut

		sOut = ""
		'loop through hash table looking for
		'a key name that matches exactly.
'		Response.write sName
'		Response.end
		For i = 0 to UBound(HashTable_Names)
			If sName = HashTable_Names(i) Then
				'if key found, return the value of the key
				sOut = HashTable_Values(i)
				Exit For
			End If
		Next
		GetValue = sOut
	End Function

	Public Function NamesCollection()
		'return the internal array of hash table keys
		NamesCollection = HashTable_Names
	End Function

	Public Function ValuesCollection()
		'return the internal array of hash table values
		ValuesCollection = HashTable_Values
	End Function
End Class

%>
