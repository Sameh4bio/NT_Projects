import React, { useState } from 'react';

function App() {
  const [message, setMessage] = useState('');
  const [parsed, setParsed] = useState(null);
  const [format, setFormat] = useState('hl7');

  const parseMessage = async () => {
    const res = await fetch('/api/viewer/parse', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ format, message })
    });
    if (res.ok) {
      setParsed(await res.json());
    }
  };

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">NT Integration Viewer</h1>
      <div className="mb-2">
        <select value={format} onChange={e => setFormat(e.target.value)} className="border p-1">
          <option value="hl7">HL7</option>
          <option value="json">JSON</option>
          <option value="xml">XML</option>
          <option value="fhir">FHIR</option>
        </select>
      </div>
      <textarea
        value={message}
        onChange={e => setMessage(e.target.value)}
        className="w-full h-40 border p-2 mb-2"
        placeholder="Paste message here"
      ></textarea>
      <button onClick={parseMessage} className="bg-blue-500 text-white px-4 py-2">Parse</button>
      {parsed && (
        <pre className="mt-4 bg-gray-200 p-2 whitespace-pre-wrap">
{JSON.stringify(parsed, null, 2)}
        </pre>
      )}
    </div>
  );
}

export default App;
