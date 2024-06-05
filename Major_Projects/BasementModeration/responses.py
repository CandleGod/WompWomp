import discord
import requests
import json

intents = discord.Intents.default()
intents.message_content = True

client = discord.Client(intents=intents)

API_KEY = '925e335f-1256-440d-8aa9-b94640b76739'

@client.event
async def on_message(message):
    if message.author == client.user:
        return

    if any(word.startswith('http') for word in message.content.split()):
        for word in message.content.split():
            if word.startswith('http'):
                url = word
                headers = {'API-Key': API_KEY, 'Content-Type': 'application/json'}
                data = json.dumps({'url': url})
                response = requests.post('https://urlscan.io/api/v1/scan/', headers=headers, data=data)

                if response.status_code == 200:
                    scan_data = response.json()
                    scan_id = scan_data.get('uuid')

                    # Polling to check the scan result
                    scan_result_url = f'https://urlscan.io/api/v1/result/{scan_id}/'
                    while True:
                        result_response = requests.get(scan_result_url)
                        if result_response.status_code == 200:
                            result_data = result_response.json()
                            if result_data['status'] == 200:
                                verdict = result_data['verdicts']['overall']['malicious']
                                if verdict:
                                    await message.channel.send(f'The link `{url}` is malicious!')
                                else:
                                    await message.channel.send(f'The link `{url}` is safe!')
                                break
                        else:
                            await message.channel.send(f'Error checking the link `{url}`: {result_response.status_code}')
                            break
                else:
                    await message.channel.send(f'Error submitting the link `{url}`: {response.status_code}')

client.run('MTI0Nzc0NTMzMTM1Mzg3ODU5MA.GYRYwo.3ouFirkCtMeLR-9q6yDTjIuG4phEF_aTOdiu7w')
