import { useNavigate } from "react-router-dom";

export default function Header() {
    const navigate = useNavigate();

    const handleCreateClick = () => {
        navigate('/product/Create');
    };
    const handleDemoClick = () => {
        navigate('/');
    };

    return (
        <nav style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: '1rem', backgroundColor: '#f0f8ff' }}>
            <div>
                <button style={{ background: 'none', border: 'none', padding: 0, fontWeight: 'bold', cursor: 'pointer' }} onClick={handleDemoClick}>Product Demo</button>
            </div>
            <div>
                <button style={{ padding: '0.5rem 1rem', borderRadius: '5px', backgroundColor: '#007bff', color: '#fff', border: 'none' }}
                    onClick={handleCreateClick}
                >Create</button>
            </div>
        </nav>
    );
}

