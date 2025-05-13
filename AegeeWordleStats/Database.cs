namespace AegeeWordleStats;

public class Database
{
        
}
/* Extracting database from google in shell ->
wabdd download --master-token /home/nemjit/tokens/tijmenpvis_gmail_com_mastertoken.txt \
--exclude "Media/WhatsApp Video/*,Media/WhatsApp Images/*" | \
tee >(sed -n 's/.*You can now run `wabdd decrypt --key-file YOUR_KEY_FILE dump \(.*\)`$/\1/p' | \
tee /home/nemjit/backups/latest_directory_name.txt | \
xargs -I {} wabdd decrypt --key-file /home/nemjit/backups/whatsapp.key dump {})

running this will get the database from google drive, and decrypt it.
The directory name will be stored in /home/nemjit/backups/latest_directory_name.txt
The database used is located in the path specified in aforementioned file + "-decrypted/Databases/msgstore.db"


SQL Query:

SELECT
       message._id,
       (CASE WHEN message.from_me IS 0
           THEN SUBSTR(jid.raw_string,1, INSTR(jid.raw_string, '@')-1) ELSE '31630562546'
       END) as phone_number,
       DATETIME(ROUND(message.timestamp / 1000), 'unixepoch') as timestamp,
       IFNULL(message.text_data, '') as text_data
   FROM message
       LEFT JOIN jid ON jid._id = message.sender_jid_row_id
   WHERE message.chat_row_id = 3476
   ORDER BY message.timestamp DESC

 */