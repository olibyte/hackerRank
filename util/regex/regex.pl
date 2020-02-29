/var[([)][0-9][\])]/g
# matches
# var(3) var[4]

/file[0\-\\_]1/g
#  file01 file-1 file\1 file_1

/[\w\-]/g
# any word character or hyphen

/\d\./g
#numbered paragraphs i.e:
#3. This third paragraph is...

/c\w\w\w\w\w\w\w\w\w\w/g
#10 character words beginning with c

/.+/
#any string of characters except a line return
/Good .+\./
#"Good night." "Good day." "Good evening." Setences beginning with 'Good'. Indeterminite repetition
/\d+/
#match any number of digits

/\s[a-z]+ed\s/
#lowercase words ending in "ed"

/\d\d\d\d*/
/\d\d\d+/
#numbers three digits or more

/colo?r/
#color and colour

#\d{3,8} \w{4} numbers with 3 to 8 digits, 4 letter words
/\d{3}-\d{3}-\d{4}/
#us phone number
/^\+(?:[0-9] ?){6,14}[0-9]$/
#all valid international phone numbers

/((?<![\\])['"])((?:.(?!(?<![\\])\1))*.?)\1/
#quoted string with escapable characters

/^\w+@\w+\.[a-z]{3}$/
#basic email validation using anchors

/\b\w+s\b/
#words that end with s using word boundaries