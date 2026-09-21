import 'package:flutter/material.dart';

class PerformanceScreen extends StatelessWidget {
  const PerformanceScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Color(0xFF1E4630)),
          onPressed: () => Navigator.maybePop(context),
        ),
        title: const Text('Performance', style: TextStyle(color: Color(0xFF1E4630), fontWeight: FontWeight.bold)),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
              child: const Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: [
                      Icon(Icons.emoji_events_outlined, color: Color(0xFF1E4630)),
                      SizedBox(width: 8),
                      Text('Overall Performance', style: TextStyle(fontWeight: FontWeight.bold)),
                    ],
                  ),
                  SizedBox(height: 6),
                  Text('75%', style: TextStyle(fontSize: 22, fontWeight: FontWeight.bold)),
                  Text('Good Performance', style: TextStyle(color: Colors.grey, fontSize: 12)),
                  SizedBox(height: 8),
                  LinearProgressIndicator(value: 0.75, color: Color(0xFF1E4630), backgroundColor: Color(0xFFE0E0E0)),
                ],
              ),
            ),
            const SizedBox(height: 12),
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Row(
                    children: [
                      Icon(Icons.smart_toy_outlined, color: Color(0xFF1E4630)),
                      SizedBox(width: 8),
                      Text('AI Performance Analysis', style: TextStyle(fontWeight: FontWeight.bold)),
                    ],
                  ),
                  const SizedBox(height: 10),
                  Container(
                    padding: const EdgeInsets.all(12),
                    decoration: BoxDecoration(color: const Color(0xFFE8F5E9), borderRadius: BorderRadius.circular(12)),
                    child: const Row(
                      children: [
                        Icon(Icons.lightbulb_outline, color: Color(0xFF2E7D32)),
                        SizedBox(width: 8),
                        Expanded(
                          child: Text(
                            'AI Insight\nYour overall Performance is good, keep improving your attendance and grades to achieve better results.',
                            style: TextStyle(fontSize: 11, color: Color(0xFF1E4630)),
                          ),
                        ),
                      ],
                    ),
                  )
                ],
              ),
            ),
            const SizedBox(height: 12),
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(color: Colors.white, borderRadius: BorderRadius.circular(16), border: Border.all(color: Colors.grey.shade200)),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Row(
                    children: [
                      Icon(Icons.bar_chart, color: Color(0xFF1E4630)),
                      SizedBox(width: 8),
                      Text('Subject Performance', style: TextStyle(fontWeight: FontWeight.bold)),
                    ],
                  ),
                  const SizedBox(height: 12),
                  _buildSubjectBar('Database Systems', 0.86, '86%'),
                  _buildSubjectBar('Data Mining', 0.78, '78%'),
                  _buildSubjectBar('Computer Vision', 0.90, '90%'),
                  _buildSubjectBar('Operating Systems', 0.82, '82%'),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }

  Widget _buildSubjectBar(String title, double progress, String percentage) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 6.0),
      child: Row(
        children: [
          SizedBox(width: 110, child: Text(title, style: const TextStyle(fontSize: 11, color: Colors.grey))),
          Expanded(
            child: LinearProgressIndicator(value: progress, color: const Color(0xFF1E4630), backgroundColor: const Color(0xFFE0E0E0)),
          ),
          const SizedBox(width: 8),
          Text(percentage, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 11)),
        ],
      ),
    );
  }
}